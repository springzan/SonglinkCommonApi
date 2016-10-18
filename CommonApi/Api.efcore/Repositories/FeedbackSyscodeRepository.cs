using Api.Domain.Entities;
using Api.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.efcore.Repositories
{
    public class FeedbackSyscodeRepository : RepositoryBase<FeedbackSyscode>, IFeedbackSyscodeRepository
    {
        /// <summary>
        /// FeedbackSyscode管理仓储实现
        /// </summary>
        /// <param name="dbContext"></param>
        public FeedbackSyscodeRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}
