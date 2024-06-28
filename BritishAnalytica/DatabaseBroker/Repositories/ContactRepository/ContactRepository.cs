using DatabaseBroker.Repositories.Common;
using Entity.Models.Contact;

namespace DatabaseBroker.Repositories.ContactRepository;

public class ContactRepository : RepositoryBase<Contact,long> ,IContactRepository
{
    protected ContactRepository(DataContext dbContext) : base(dbContext)
    {
    }
}