using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight_Watchers.core.Response
{
    public class BaseResponse
    {
        public bool Succeed { get; set; }

        public string Message { get; set; }
        
        public BaseResponse()
        {
        }
    }
}
