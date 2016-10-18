using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Syscode : Entity
    {
        public string Category { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int Delflag { get; set; }
        public int SortNo { get; set; }
    }
}
