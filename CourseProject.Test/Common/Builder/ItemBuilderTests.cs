using CourseProject.Common.Builder;
using CourseProject.Common.Contract;
using NUnit.Framework;

namespace CourseProject.Test.Common.Builder
{
    [TestFixture]
    public class ItemBuilderTests
    {
        [Test]
        public void InitEntity()
        {
            var item = new ItemBuilder()
                .Build();
            
            Assert.IsInstanceOf<IItem>(item);
            Assert.AreEqual(0, item.Id);
            Assert.AreEqual(string.Empty, item.Description);
            Assert.AreEqual( 0.0, item.Amount, 0.0001);
        }

        [Test]
        public void BuildItemFromValues()
        {
            int id = 1;
            double amount = 1.23;
            string desc = "An Item";
            
            var item = new ItemBuilder()
                .SetId(id)
                .SetAmount(amount)
                .SetDescription(desc)
                .Build();
            
            Assert.IsInstanceOf<IItem>(item);
            Assert.AreEqual(id, item.Id);
            Assert.AreEqual(desc, item.Description);
            Assert.AreEqual( amount, item.Amount, 0.0001);
        }
        
        [Test]
        public void BuildItemFromEntity()
        {
            int id = 1;
            double amount = 1.23;
            string desc = "An Item";
            
            var item1 = new ItemBuilder()
                .SetId(id)
                .SetAmount(amount)
                .SetDescription(desc)
                .Build();

            var item2 = new ItemBuilder()
                .FromEntity(item1)
                .SetAmount(amount * 2)
                .Build();
            
            Assert.IsInstanceOf<IItem>(item1);
            Assert.AreEqual(id, item2.Id);
            Assert.AreEqual(desc, item2.Description);
            Assert.AreEqual( amount * 2, item2.Amount, 0.0001);
        }
    }
}