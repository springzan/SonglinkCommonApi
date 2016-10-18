using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonApi.Models.RequestModel
{
    public class FeedbackRequest
    {
        public string sysCode { get; set; }
        public int[] questionType { get; set; }
        public string description { get; set; }
        public string connectTel { get; set; }
        public int? agentId { get; set; }
        public string agentName { get; set; }
        public DeviceInfo deviceInfo { get; set; }
        public AppInfo appInfo { get; set; }
    }

    public class DeviceInfo
    {
        public string opreateSys { get; set; }
        public string device { get; set; }
    }
    public class AppInfo
    {
        public string app { get; set; }
        public string appVesion { get; set; }
    }
}
