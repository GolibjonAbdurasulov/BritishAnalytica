using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.Contact;
using Entity.Models.Contact.EmailModel;
using Entity.Models.Contact.PhoneNumberModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseBroker.Repositories.ContactRepository.EmailRepository;
[Injectable]
public class EmailRepository : RepositoryBase<Email,long>, IEmailRepository
{
    public EmailRepository(DataContext dbContext) : base(dbContext)
    {
    }
}