using DatabaseBroker.Repositories.Common;
using Entity.Models.CategoryModel;

namespace DatabaseBroker.Repositories.CategoryRepository;

public interface ICategoryRepository : IRepositoryBase<Category,long>
{
    
}