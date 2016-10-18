using Api.Domain.Entities;
using Api.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.application.FeedbackSyscodeApp
{
    public class FeedbackSyscodeAppService : IFeedbackSyscodeAppService
    {
        private readonly IFeedbackSyscodeRepository _feedbackSyscodeRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="feedbackRepository">仓储对象</param>
        public FeedbackSyscodeAppService(IFeedbackSyscodeRepository feedbackSyscodeRepository)
        {
            _feedbackSyscodeRepository = feedbackSyscodeRepository;
        }
        public List<FeedbackSyscode> GetAll()
        {
            return _feedbackSyscodeRepository.GetAllList();
        }

        public FeedbackSyscode CreateEntity(FeedbackSyscode model)
        {
            FeedbackSyscode newT = _feedbackSyscodeRepository.Insert(model);
            _feedbackSyscodeRepository.Save();
            return newT;
        }
    }
}
