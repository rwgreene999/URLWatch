using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLWatch
{
    public class Options
    {
        public string Uri { get; set; }
        public int msReAccess { get; set; }
        public DateTime Started { get; set; }
        public int cntAccess { get; set; } = 0;
        public int cntFailures { get; set; } = 0;
        public long msAvgResponseTime { get; set; } = 0;

        public List<AccessResponse> AccessResponses { get; set; } = new List<AccessResponse>();
        public List<AccessResponse> AccessFailures { get; set; } = new List<AccessResponse>();
        public int MaxAccessResponse { get; set; } = 1000;

        public bool Paused { get; internal set; }
    }

}
