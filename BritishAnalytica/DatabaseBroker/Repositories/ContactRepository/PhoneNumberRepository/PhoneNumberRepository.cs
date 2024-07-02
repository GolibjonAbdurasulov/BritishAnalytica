using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.Contact.PhoneNumberModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.ContactRepository.PhoneNumberRepository;
[Injectable]
public class PhoneNumberRepository : RepositoryBase<PhoneNumber,long>, IPhoneNumberRepository
{
    public PhoneNumberRepository(DataContext dbContext) : base(dbContext)
    {
    }
}