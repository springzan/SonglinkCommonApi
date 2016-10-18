using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.IRepositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Feedback GetEntityByID(int id);
    }
}
