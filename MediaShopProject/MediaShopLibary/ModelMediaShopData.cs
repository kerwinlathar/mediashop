namespace MediaShopLibary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelMediaShopData : DbContext
    {
        public IDbSet<Customer> customers { get; set; }
        public IDbSet<Books> books { get; set; }
        public IDbSet<DVD> dvd { get; set; }
        public IDbSet<Order> order { get; set; }

        public ModelMediaShopData()
            : base("name=ModelMediaShopData")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
