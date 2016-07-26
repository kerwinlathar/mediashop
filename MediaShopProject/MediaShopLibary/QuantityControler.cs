using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLibary
{
    public class QuantityControler : IQuantityRepostiory
    {
        private ModelMediaShopData content;

        public QuantityControler(ModelMediaShopData content)
        {
            this.content = content;
        }


        public decimal OrderBook(int bookIdToOrder, int quantityToOrder)
        {
            var testdata = content.books.Where(x => x.id == bookIdToOrder).Count();
            if (testdata != 0)
            {
                var databook = content.books.Where(x => x.id == bookIdToOrder).First();

                databook.quantity = databook.quantity + quantityToOrder;

                content.SaveChanges();

                return databook.price * quantityToOrder;
            }
            else
            {
                return 0m;
            }
        }

        public decimal OrderDvd(int dvdIdToOrder, int quantityToOrder)
        {
            var testdata = content.dvd.Where(x => x.id == dvdIdToOrder).Count();
           
            if (testdata != 0 )
            {
                var datadvd = content.dvd.Where(x => x.id == dvdIdToOrder).First();

                datadvd.quantity = datadvd.quantity + quantityToOrder;

                content.SaveChanges();

                return datadvd.price * quantityToOrder;
            }
            else
            {
                return 0m;
            }
        }

        public decimal BuyBook(int bookIdToOrder, int customerId, int quantityToOrder)
        {
            var testdata = content.books.Where(x => x.id == bookIdToOrder).Count();
            

            if (testdata != 0 )
            {
                var testquant = content.books.Where(x => x.id == bookIdToOrder).FirstOrDefault().quantity;
                if (testquant > 0)
                {
                    var databook = content.books.Where(x => x.id == bookIdToOrder).First();

                    databook.quantity = databook.quantity - 1;

                    var orderidfinal = content.order.Last().id++;


                    content.order.Add(new Order() { id = orderidfinal, customer_id = customerId, book_id = bookIdToOrder });

                    content.SaveChanges();

                    return databook.price;
                }
                else
                {
                    return 0m;
                }
            }

            else
            {
                return 0m;
            }
        }


        public List<Order> GetAllOrders()
        {
            return content.order.ToList();
        }



        public decimal BuyDvd(int dvdIdToOrder, int customerId, int quantityToOrder)
        {

            var testdata = content.dvd.Where(x => x.id == dvdIdToOrder).Count();
            if (testdata != 0)
            {
                var testquant = content.dvd.Where(x => x.id == dvdIdToOrder).FirstOrDefault().quantity;
                if (testquant > 0)
                {
                    var datadvd = content.dvd.Where(x => x.id == dvdIdToOrder).First();

                    datadvd.quantity = datadvd.quantity - 1;

                    var orderidfinal = content.order.Last().id++;



                    content.order.Add(new Order() { id = orderidfinal, customer_id = customerId, dvd_id = dvdIdToOrder });

                    content.SaveChanges();

                    return datadvd.price;
                }
                else
                {
                    return 0m;
                }
            }

            else
            {
                return 0m;
            }
        }



    }
}
