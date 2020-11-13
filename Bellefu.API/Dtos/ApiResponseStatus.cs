using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Dtos
{
    public class ApiResponseStatus
    {
        
            //public APIResponseStatus();
            public bool IsSuccessful { get; set; }
            public string CustomToken { get; set; }
            public string CustomSetting { get; set; }
            public APIResponseMessage Message { get; set; }
    }


        public class APIResponseMessage
        {
            //public APIResponseMessage();

            public string FriendlyMessage { get; set; }
            public string TechnicalMessage { get; set; }
            public string MessageId { get; set; }
            public string SearchResultMessage { get; set; }
            public string ShortErrorMessage { get; set; }
        }
    
}
