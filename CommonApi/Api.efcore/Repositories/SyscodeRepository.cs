using Api.Domain.Entities;
using Api.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.efcore.Repositories
{
    public class SyscodeRepository : RepositoryBase<Syscode>, ISyscodeRepository
    {
        /// <summary>
        /// Syscode管理仓储实现
        /// </summary>
        /// <param name="dbContext"></param>
        public SyscodeRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }

        public List<Syscode> GetAllByCategory(string category)
        {
            return _dbContext.Set<Syscode>().Where(sc=>sc.Category==category).ToList();
        }
    }
}
