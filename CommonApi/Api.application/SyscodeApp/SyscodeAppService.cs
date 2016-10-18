using Api.Domain.Entities;
using Api.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.application.SyscodeApp
{
    /// <summary>
    /// Syscode管理服务
    /// </summary>
    public class SyscodeAppService: ISyscodeAppService
    {
        //Syscode管理仓储接口
        private readonly ISyscodeRepository _syscodeRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="syscodeRepository">仓储对象</param>
        public SyscodeAppService(ISyscodeRepository syscodeRepository)
        {
            _syscodeRepository = syscodeRepository;
        }

        public List<Syscode> GetAll()
        {
            return _syscodeRepository.GetAllList();
        }

        public List<Syscode> GetAllByCategory(string category)
        {
            return _syscodeRepository.GetAllByCategory(category);
        }
    }
}
