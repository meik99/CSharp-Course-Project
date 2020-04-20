using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseProject.Common.Contract;
using CourseProject.Database.Repository.Memory;

namespace CourseProject.Database.Repository.Facade
{
    public class ItemFacade
    {
        private static IItemRepository _itemRepository;

        public ItemFacade(IItemRepository repository)
        {
            _itemRepository ??= 
                repository ?? 
                throw new NullReferenceException($"{nameof(repository)} must not be null");
        }

        public ItemFacade() : this(new ItemRepository()) {}

        public Task<List<IItem>> FindAll()
        {
            return _itemRepository.FindAll();
        }

        public Task<IItem> Insert(IItem entity)
        {
            return _itemRepository.Insert(entity);
        }

        public Task<IItem> Update(IItem entity)
        {
            return _itemRepository.Update(entity);
        }
    }
}