using DatabaseBroker.Repositories.Common;

namespace DatabaseBroker.Repositories.FaqQuestionsRepository;

public interface IFaqQuestionRepository : IRepositoryBase<Entity.Models.FaqQuestion.FaqQuestions,long>
{
    
}