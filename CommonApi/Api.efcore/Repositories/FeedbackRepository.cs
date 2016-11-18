using Api.Domain.Entities;
using Api.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.efcore.Repositories
{
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        /// <summary>
        /// Feedback管理仓储实现
        /// </summary>
        /// <param name="dbContext"></param>
        public FeedbackRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }

        public Feedback GetEntityByID(int id)
        {
            _dbContext.Set<Feedback>().
            return _dbContext.Set<Feedback>().FirstOrDefault(f => f.ID == id);
        }
    }
}
