using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.application.FeedbackSyscodeApp
{
    public interface IFeedbackSyscodeAppService
    {
        List<FeedbackSyscode> GetAll();

        FeedbackSyscode CreateEntity(FeedbackSyscode model);
    }
}
