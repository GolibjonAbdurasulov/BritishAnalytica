using DatabaseBroker.Repositories.Common;
using Entity.Models.Contact.PhoneNumberModel;

namespace DatabaseBroker.Repositories.ContactRepository.PhoneNumberRepository;

public interface IPhoneNumberRepository : IRepositoryBase<PhoneNumber,long>
{
    
}