using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class FeedbackSyscode : Entity
    {
        public int ID { get; set; }
        public int feedID { get; set; }
        public string Code { get; set; }
        public int CodeKey { get; set; }
    }
}
