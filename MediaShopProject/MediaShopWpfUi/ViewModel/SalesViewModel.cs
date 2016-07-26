using MediaShopLibary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopWpfUi.ViewModel
{
    public class SalesViewModel:AbstractViewModel
    {
        private  QuantityControler quantcontrol;


        public SalesViewModel()
        {
            this.quantcontrol = new QuantityControler(new ModelMediaShopData());
            orderList = new ObservableCollection<Order>(quantcontrol.GetAllOrders());
        }

        private ObservableCollection<Order> _orderList;

        public ObservableCollection<Order> orderList
        {
            get { return _orderList; }
            set
            {
                _orderList = value;
                OnPropertyChanged("orderList");
            }
        }
    }
}
