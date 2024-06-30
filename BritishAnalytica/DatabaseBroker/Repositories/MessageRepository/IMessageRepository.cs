using DatabaseBroker.Repositories.Common;
using Entity.Models.MessageModel;

namespace DatabaseBroker.Repositories.MessageRepository;

public interface IMessageRepository : IRepositoryBase<Message,long>
{
    
}