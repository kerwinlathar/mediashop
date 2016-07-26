using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaShopLibary
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
       
    }
}
