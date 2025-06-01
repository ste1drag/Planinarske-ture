using Reviewing.Application.Contracts;
using Reviewing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO 
// Change wildcard type to dto type that w define in contracts
public interface IReviewRepository : IAsyncRepository<Review>
{
    public Task<IReadOnlyCollection<Review>> getReviewByUsername(string username);
}
