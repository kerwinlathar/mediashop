using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLibary
{
    public interface IQuantityRepostiory
    {
        decimal OrderBook(int bookIdToOrder, int quantityToOrder);
        decimal OrderDvd(int dvdIdToOrder, int quantityToOrder);
        decimal BuyBook(int bookIdToOrder, int customerId, int quantityToOrder);
        decimal BuyDvd(int dvdIdToOrder, int customerId, int quantityToOrder);


    }
}
