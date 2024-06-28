using DatabaseBroker.Repositories.Common;

namespace DatabaseBroker.Repositories.FaqQuestionsRepository;

public class FaqQuestionRepository : RepositoryBase<Entity.Models.FaqQuestion.FaqQuestions,long> ,IFaqQuestionRepository
{
    protected FaqQuestionRepository(DataContext dbContext) : base(dbContext)
    {
    }
}