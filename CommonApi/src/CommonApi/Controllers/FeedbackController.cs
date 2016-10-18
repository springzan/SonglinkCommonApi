
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.application.FeedbackApp;
using Api.Domain.Entities;
using CommonApi.Models.RequestModel;
using System;
using Newtonsoft.Json;
using Api.application.FeedbackSyscodeApp;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommonApi.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackAppSevice _feedbackAppSevice;
        private readonly IFeedbackSyscodeAppService _feedbackSyscodeAppService;
        public FeedbackController(IFeedbackAppSevice feedbackAppSevice, IFeedbackSyscodeAppService feedbackSyscodeAppService)
        {
            _feedbackAppSevice = feedbackAppSevice;
            _feedbackSyscodeAppService = feedbackSyscodeAppService;
        }
        // GET: api/feedback
        [HttpGet]
        public IEnumerable<Feedback> Get()
        {
            var feedbacks= _feedbackAppSevice.GetAll();
            return feedbacks;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Feedback Get(int id)
        {
            //var model = _feedbackAppSevice.GetEntityByID(id);
            var model = _feedbackAppSevice.GetEntity(f=>f.ID==id);
            return model;
        }

        // POST api/values
        [HttpPost]
        public Feedback Post([FromBody]FeedbackRequest request)
        {
            if (request != null)
            {
                Feedback m = new Feedback();
                m.QuestionType = JsonConvert.SerializeObject(request.questionType);
                m.Description = request.description;
                m.ConnectTel = request.connectTel;
                m.Status = 0;
                m.CreateTime = DateTime.Now;
                m.AgentId = request.agentId;
                m.AgentName = request.agentName;
                if (request.deviceInfo != null)
                {
                    m.System = request.deviceInfo.opreateSys;
                    m.Device = request.deviceInfo.device;
                }
                if (request.appInfo != null)
                {
                    m.App = request.appInfo.app;
                    m.AppVesion = request.appInfo.appVesion;
                }
                Feedback newT=_feedbackAppSevice.CreateEntity(m);
                if (newT.ID > 0)
                {
                    foreach(var i in request.questionType)
                    {
                        FeedbackSyscode fs = new FeedbackSyscode();
                        fs.feedID = newT.ID;
                        fs.Code = request.sysCode;
                        fs.CodeKey = i;
                        FeedbackSyscode nfs=_feedbackSyscodeAppService.CreateEntity(fs);
                    }
                }
                return newT;
            }
            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
