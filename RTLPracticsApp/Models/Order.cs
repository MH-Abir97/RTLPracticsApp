using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RTLPracticsApp.Models
{
    public class Order
    {
        [Key]
        public int OrderOId { get; set; }
        public string OrderNo { get; set; }
      
        public List<Item> Item { get; set; }
        [NotMapped]
        public string ItemName { get; set; }
    }
}