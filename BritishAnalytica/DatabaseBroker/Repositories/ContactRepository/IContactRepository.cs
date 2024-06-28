using DatabaseBroker.Repositories.Common;
using Entity.Models.Contact;

namespace DatabaseBroker.Repositories.ContactRepository;

public interface IContactRepository : IRepositoryBase<Contact,long>
{
    
}