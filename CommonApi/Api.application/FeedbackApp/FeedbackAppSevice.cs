using Api.Domain.Entities;
using Api.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.application.FeedbackApp
{
    public class FeedbackAppSevice: IFeedbackAppSevice
    {
        //Feedback管理仓储接口
        private readonly IFeedbackRepository _feedbackRepository;

        /// <summary>
        /// 构造函数 实现依赖注入
        /// </summary>
        /// <param name="feedbackRepository">仓储对象</param>
        public FeedbackAppSevice(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public List<Feedback> GetAll()
        {
            return _feedbackRepository.GetAllList();
        }

        public Feedback GetEntityByID(int id)
        {
            return _feedbackRepository.GetEntityByID(id);
        }

        public Feedback GetEntity(Expression<Func<Feedback, bool>> predicate)
        {
            return _feedbackRepository.FirstOrDefault(predicate);
        }

        public Feedback CreateEntity(Feedback model)
        { 
            Feedback newT= _feedbackRepository.Insert(model);
            _feedbackRepository.Save();
            return newT; 
        }
    }
}
