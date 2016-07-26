using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLibary
{
    public class Order
    {
        public int id { get; set; }
        public int customer_id{ get; set; }
        public Customer customer { get; set; }
        public int book_id { get; set; }
        public Books book { get; set; }
        public int dvd_id { get; set; }
        public DVD dvd { get; set; }
    }
}
