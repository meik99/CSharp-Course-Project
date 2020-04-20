using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Common.Builder;
using CourseProject.Common.Contract;

namespace CourseProject.Database.Repository.Memory
{
    internal class ItemRepository : IItemRepository
    {
        private const int MAX_TRIES = 3;
            
        private SpinLock _spinLock = new SpinLock(true);
        private volatile List<IItem> _items = new List<IItem>();
        
        public Task<List<IItem>> FindAll()
        {
            return new Task<List<IItem>>(() => _items);
        }

        public Task<IItem> Insert(IItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            
            var task = new Task<IItem>(() =>
            {
                Lock();
                
                int nextId = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
                var result = new ItemBuilder()
                    .FromEntity(entity)
                    .SetId(nextId)
                    .Build();
                
                _items.Add(result);
                _items.Sort((a,b) => a.Id.CompareTo(b.Id));
                
                Unlock();

                return result;
            });
            
            return task;
        }

        public Task<IItem> Update(IItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            
            return new Task<IItem>(() =>
            {
                var item = _items.Find(i => i.Id == entity.Id);

                if (item == null)
                {
                    return null;
                }
                
                Lock();

                _items.Remove(item);
                _items.Add(entity);
                _items.Sort((a,b) => a.Id.CompareTo(b.Id));
                
                Unlock();
                
                return entity;
            });
        }

        private void Lock()
        {
            bool hasToken = false;
            int tries = 0;

            do
            {
                if (tries > MAX_TRIES)
                {
                    throw new Exception("Could not acquire lock");
                }
                    
                tries++;
                _spinLock.Enter(ref hasToken);
            } while (!hasToken);
        }

        private void Unlock()
        {
            _spinLock.Exit();
        }
    }
}