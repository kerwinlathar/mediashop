using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLibary
{
    public class DVD:Item
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        
    }
}
