using System.Threading.Tasks;
using CourseProject.Common.Builder;
using NUnit.Framework;

namespace CourseProject.Database.Repository.Memory
{
    [TestFixture]
    public class ItemRepositoryTests
    {
        [Test]
        public async Task Insert()
        {
            ItemRepository repository = new ItemRepository();
            var task = repository.Insert(new ItemBuilder()
                .SetAmount(1)
                .SetDescription("Test 1")
                .Build());
            var item = await task;

            Assert.NotNull(item);
            Assert.AreEqual(1, item.Id, 0.0001);
            Assert.AreEqual(1, item.Amount, 0.0001);
            Assert.AreEqual("Test 1", item.Description);
            
        }
        
        [Test]
        public async Task Update()
        {
            ItemRepository repository = new ItemRepository();
            var task = repository.Insert(new ItemBuilder()
                .SetAmount(1)
                .SetDescription("Test 1")
                .Build());
            var item = await task;

            Assert.NotNull(item);
            Assert.AreEqual(1, item.Id, 0.0001);
            Assert.AreEqual(1, item.Amount, 0.0001);
            Assert.AreEqual("Test 1", item.Description);

            task = repository.Update(new ItemBuilder()
                .FromEntity(item)
                .SetAmount(2)
                .SetDescription("Test 2")
                .Build());
            item = await task;

            Assert.NotNull(item);
            Assert.AreEqual(1, item.Id, 0.0001);
            Assert.AreEqual(2, item.Amount, 0.0001);
            Assert.AreEqual("Test 2", item.Description);
        }
        
        [Test]
        public async Task Delete()
        {
            ItemRepository repository = new ItemRepository();
            var task = repository.Insert(new ItemBuilder()
                .SetAmount(1)
                .SetDescription("Test 1")
                .Build());
            var item = await task;

            Assert.NotNull(item);
            Assert.AreEqual(1, item.Id, 0.0001);
            Assert.AreEqual(1, item.Amount, 0.0001);
            Assert.AreEqual("Test 1", item.Description);
            
            var items = await repository.FindAll();
            int length = items.Count;
            
            await repository.Delete(item.Id);
            items = await repository.FindAll();
            
            Assert.AreEqual(length-1, items.Count, 0.001);
        }
    }
}