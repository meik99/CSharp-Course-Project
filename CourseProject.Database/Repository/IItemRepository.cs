using System.Collections.Generic;
using System.Threading.Tasks;
using CourseProject.Common.Contract;

namespace CourseProject.Database.Repository
{
    public interface IItemRepository
    {
        Task<List<IItem>> FindAll();
        Task<IItem> Insert(IItem entity);
    }
}