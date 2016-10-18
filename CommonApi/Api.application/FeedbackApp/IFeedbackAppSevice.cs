using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.application.FeedbackApp
{
    public interface IFeedbackAppSevice
    {
        List<Feedback> GetAll();

        Feedback GetEntityByID(int id);

        Feedback GetEntity(Expression<Func<Feedback, bool>> predicate);

        Feedback CreateEntity(Feedback model);
    }
}
