using Reviewing.Application.Contracts;
using Reviewing.Application.DTOs;
using Reviewing.Domain.Entities;

// TODO 
// Change wildcard type to dto type that w define in contracts

namespace Reviewing.Application.Contracts
{

    public interface IReviewRepository : IAsyncRepository<ReadReviewDto>
    {
        public Task<IReadOnlyCollection<ReadReviewDto>> GetReviewByUsername(string username);
    }
}
