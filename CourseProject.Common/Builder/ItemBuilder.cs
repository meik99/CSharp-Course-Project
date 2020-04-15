using CourseProject.Common.Contract;
using CourseProject.Common.Entity;
using CourseProject.Common.Factory;

namespace CourseProject.Common.Builder
{
    public class ItemBuilder
    {
        private readonly Item _item = new Item()
        {
            Id = 0,
            Description = string.Empty,
            Amount = 0.0
        };

        public ItemBuilder SetAmount(double amount)
        {
            _item.Amount = amount;
            return this;
        }

        public ItemBuilder SetDescription(string description)
        {
            _item.Description = description;
            return this;
        }

        public ItemBuilder SetId(int id)
        {
            _item.Id = id;
            return this;
        }

        public ItemBuilder FromEntity(IItem entity)
        {
            _item.Id = entity.Id;
            _item.Amount = entity.Amount;
            _item.Description = entity.Description;
            return this;
        }

        public IItem Build() => new Item
        {
            Id = _item.Id,
            Description = _item.Description,
            Amount = _item.Amount
        };

    }
}