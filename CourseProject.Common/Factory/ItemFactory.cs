using System;
using CourseProject.Common.Contract;
using CourseProject.Common.Entity;

namespace CourseProject.Common.Factory
{
    public class ItemFactory
    {
        public IItem New() => new Item
        {
            Id = 0,
            Amount = 0.0,
            Description = String.Empty
        };
    }
}