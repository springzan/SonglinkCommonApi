using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.application.SyscodeApp;
using Api.Domain.Entities;
using CommonApi.Models.RequestModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommonApi.Controllers
{
    [Route("api/[controller]")]
    public class SyscodeController : Controller
    {
        private readonly ISyscodeAppService _syscodeAppService;
        public SyscodeController(ISyscodeAppService syscodeAppService)
        {
            _syscodeAppService = syscodeAppService;
        }

        // GET api/syscode
        [HttpGet]
        public IEnumerable<Syscode> Get()
        {
            var codes = _syscodeAppService.GetAll();
            return codes;
        }

        // GET api/syscode/category
        [HttpGet("{category}")]
        public IEnumerable<Syscode> Get(string category)
        {
            //var codes = _dbContext.Set<Syscode>().Where(sc=>sc.Category==category).ToList();
            //var codes = _syscodeAppService.GetAllByCategory(category);
            return _syscodeAppService.GetAllByCategoryAndDelFlag(category,0);
        }


        [HttpPost]
        public IEnumerable<Syscode> Post([FromBody] SyscodeRequest syscode)
        {
            if (syscode != null && !string.IsNullOrEmpty(syscode.category))
            {
                //return _syscodeAppService.GetAllByCategory(syscode.category);
                return _syscodeAppService.GetAllByCategoryAndDelFlag(syscode.category, 0);
            }
            return _syscodeAppService.GetAll();
        }
    }
}
