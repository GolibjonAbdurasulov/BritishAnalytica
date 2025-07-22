using DatabaseBroker.Repositories.Common;
using Entity.Attributes;

namespace DatabaseBroker.Repositories.FaqQuestionsRepository;
[Injectable]
public class FaqQuestionRepository : RepositoryBase<Entity.Models.FaqQuestion.FaqQuestions,long> ,IFaqQuestionRepository
{
    public FaqQuestionRepository(DataContext dbContext) : base(dbContext)
    {
    }
}