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
            task.Start();
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
            task.Start();
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
            task.Start();
            item = await task;

            Assert.NotNull(item);
            Assert.AreEqual(1, item.Id, 0.0001);
            Assert.AreEqual(2, item.Amount, 0.0001);
            Assert.AreEqual("Test 2", item.Description);
        }
    }
}