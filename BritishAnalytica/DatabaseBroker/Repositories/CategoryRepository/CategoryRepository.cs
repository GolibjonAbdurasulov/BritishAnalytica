using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.CategoryModel;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.CategoryRepository;
[Injectable]
public class CategoryRepository : RepositoryBase<Category,long>, ICategoryRepository 
{
    public CategoryRepository(DataContext dbContext) : base(dbContext)
    {
    }
}