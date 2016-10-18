using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.application.SyscodeApp
{
    public interface ISyscodeAppService
    {
        List<Syscode> GetAll();

        List<Syscode> GetAllByCategory(string category);

        List<Syscode> GetAllByCategoryAndDelFlag(string category,int del);
    }
}
