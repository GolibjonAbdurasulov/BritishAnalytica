using DatabaseBroker.Repositories.Common;
using Entity.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.UserRepository;

public class UserRepository : RepositoryBase<User,long> ,IUserRepository
{
    protected UserRepository(DataContext dbContext) : base(dbContext)
    {
    }
}