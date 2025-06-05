using Reviewing.Application.DTOs;
namespace Reviewing.Application.Contracts
{

    public interface IReviewRepository : IAsyncRepository<ReadReviewDto>
    {
        public Task<IReadOnlyCollection<ReadReviewDto>> GetReviewByUsername(string username);
    }
}
