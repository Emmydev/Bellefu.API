using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Dtos
{
    public class OrderObj
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string MenuName { get; set; }
        public string PhoneContact { get; set; }

        public string DeliveryStatusName { get; set; }

        public int MenuId { get; set; }
        public DateTime RequestDate { get; set; }
        public int Quantity { get; set; }

        public decimal ActualCost { get; set; }
        public int DeliveryStatus { get; set; }

        public bool? Active { get; set; }

        public bool? Deleted { get; set; }

        
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
    public class OrderObjRespObj
    {
        public IEnumerable<OrderObj> Order { get; set; }

        public ApiResponseStatus Status { get; set; }
    }
}
