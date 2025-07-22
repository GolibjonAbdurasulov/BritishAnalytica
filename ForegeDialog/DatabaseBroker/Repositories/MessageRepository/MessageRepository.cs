using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Entity.Models.MessageModel;

namespace DatabaseBroker.Repositories.MessageRepository;

[Injectable]
public class MessageRepository : RepositoryBase<Message,long>, IMessageRepository
{
    public MessageRepository(DataContext dbContext) : base(dbContext)
    {
    }
}