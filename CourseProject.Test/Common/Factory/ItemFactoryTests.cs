using CourseProject.Common.Contract;
using CourseProject.Common.Factory;
using NUnit.Framework;

namespace CourseProject.Test.Common.Factory
{
    [TestFixture]
    public class ItemFactoryTests
    {
        /// <summary>
        /// Initializes the Item entity with an ItemFactory
        /// </summary>
        [Test]
        public void InitEntity()
        {
            var item = new ItemFactory().New();

            Assert.IsInstanceOf<IItem>(item);
            Assert.AreEqual(0, item.Id);
            Assert.AreEqual(string.Empty, item.Description);
            Assert.AreEqual( 0.0, item.Amount, 0.0001);
        }
    }
}