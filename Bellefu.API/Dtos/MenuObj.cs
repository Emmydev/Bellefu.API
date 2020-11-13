using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Dtos
{
    public class MenuObj
    {    
        public int MenuId { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        public decimal Cost { get; set; }

        public bool? Active { get; set; }

        public bool? Deleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }

    public class MenuObjRespObj
    {
        public IEnumerable<MenuObj> Menu { get; set; }

        public ApiResponseStatus Status { get; set; }
    }
}
