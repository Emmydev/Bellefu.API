using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Dtos
{
    public class CustomerObj
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public string PhoneContact { get; set; }

        public bool? Active { get; set; }

        public bool? Deleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }

    public class CustomerObjRespObj
    {
        public IEnumerable<CustomerObj> Customers { get; set; }
        public ApiResponseStatus Status { get; set; }
    }
}
