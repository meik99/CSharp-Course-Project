using CourseProject.Common.Contract;

namespace CourseProject.Common.Entity
{
    internal class Item : IItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}