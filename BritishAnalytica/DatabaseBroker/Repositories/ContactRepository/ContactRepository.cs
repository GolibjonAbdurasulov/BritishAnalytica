using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.Contact;

namespace DatabaseBroker.Repositories.ContactRepository;
[Injectable]
public class ContactRepository : RepositoryBase<Contact,long> ,IContactRepository
{
    public ContactRepository(DataContext dbContext) : base(dbContext)
    {
    }
}