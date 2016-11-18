using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class Feedback : Entity
    {
        public int ID { get; set; }
        public string QuestionType { get; set; }
        public string Description { get; set; }
        public string ConnectTel { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int? AgentId { get; set; }
        public string AgentName { get; set; }
        public string System { get; set; }
        public string Device { get; set; }
        public string App { get; set; }
        public string AppVesion { get; set; }
        public string Feeder { get; set; }
        public string FeedInfo { get; set; }
        public DateTime? FeedTime { get; set; }

    }
}
