using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.IRepositories
{
    /// <summary>
    /// Syscode管理仓储接口
    /// </summary>
    public interface ISyscodeRepository : IRepository<Syscode>
    {
        List<Syscode> GetAllByCategory(string category);
    }
}
