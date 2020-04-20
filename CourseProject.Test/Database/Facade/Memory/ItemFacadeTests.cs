using System.Collections.Generic;
using System.Threading.Tasks;
using CourseProject.Common.Builder;
using CourseProject.Common.Contract;
using CourseProject.Common.Factory;
using CourseProject.Database.Repository;
using CourseProject.Database.Repository.Facade;
using NUnit.Framework;

namespace CourseProject.Test.Database.Facade.Memory
{
    [TestFixture]
    public class InMemoryTests
    {
        private class MockRepository: IItemRepository
        {
            public Task<List<IItem>> FindAll()
            {
                return new Task<List<IItem>>(() =>
                {
                    var item = new ItemBuilder()
                        .SetId(1)
                        .SetDescription("Tests")
                        .SetAmount(1.23)
                        .Build();
                    var list = new List<IItem>();
                    list.Add(item);

                    return list;
                });
            }

            public Task<IItem> Insert(IItem entity)
            {
                return new Task<IItem>(() =>
                {
                    var item = new ItemBuilder()
                        .SetId(2)
                        .Build();
                    return item;
                });
            }

            public Task<IItem> Update(IItem entity)
            {
                return Insert(entity);
            }
        }
        
        [Test]
        public void InitFacade()
        {
            var facade = new ItemFacade();
        }

        [Test]
        public void GetAll()
        {
            var facade = new ItemFacade(new MockRepository());
            var task = facade.FindAll();
            
            task.Start();
            task.Wait();

            var items = task.Result;
            
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(1, items[0].Id);
            Assert.AreEqual(1.23, items[0].Amount);
            Assert.AreEqual("Tests", items[0].Description);
        }

        [Test]
        public void Insert()
        {
            var facade = new ItemFacade(new MockRepository());
            var task = facade.Insert(new ItemFactory().New());
            
            task.Start();
            task.Wait();

            var item = task.Result;
            
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual(0.0, item.Amount);
            Assert.AreEqual("", item.Description);
        }
        
        [Test]
        public void Update()
        {
            var facade = new ItemFacade(new MockRepository());
            var task = facade.Update(new ItemFactory().New());
            
            task.Start();
            task.Wait();

            var item = task.Result;
            
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual(0.0, item.Amount);
            Assert.AreEqual("", item.Description);
        }
    }
}