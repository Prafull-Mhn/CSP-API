using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Domain.Entities
{
    public class HLRList
    {
       
            public bool status { get; }
            public int response_code { get; set; }
            public IEnumerable<opertaorDetail> info { get; set; }
            public string message { get; set; }

        

        public class opertaorDetail
        {
            public string Operator { get; set; }
            public string circle { get; set; }
        }
    }
}
