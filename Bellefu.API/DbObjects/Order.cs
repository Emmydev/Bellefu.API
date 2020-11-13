using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.DbObjects
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int MenuId { get; set; }

        [StringLength(50)]
        public DateTime RequestDate { get; set; }

        [StringLength(500)]
        public int Quantity { get; set; }

        [StringLength(500)]
        public decimal ActualCost { get; set; }
        public int DeliveryStatus { get; set; }

        public bool? Active { get; set; }

        public bool? Deleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
