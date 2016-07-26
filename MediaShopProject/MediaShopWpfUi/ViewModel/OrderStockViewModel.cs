using MediaShopLibary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaShopWpfUi.ViewModel
{
    public class OrderStockViewModel: AbstractViewModel
    {
        private ItemController itemcontrol;
        private QuantityControler quantcontrol;


           public OrderStockViewModel()
           {
               this.itemcontrol= new ItemController(new ModelMediaShopData());
               this.quantcontrol = new QuantityControler(new ModelMediaShopData());

               dvdList = new ObservableCollection<DVD>(itemcontrol.GetAllDVDs());
               bookList = new ObservableCollection<Books>(itemcontrol.GetAllBooks());
           }

           private int _id;
           public int id
           {
               get { return _id; }

               set
               {
                   
                   _id = value;
                   OnPropertyChanged("id");
               }
           }


           private int _quantity;
           public int quantity
           {
               get { return _quantity; }

               set
               {
                   _quantity = value;
                   OnPropertyChanged("quantity");
               }
           }

           private decimal _price;
           public decimal price
           {
               get { return _price; }

               set
               {
                  

                   _price = value;
                   OnPropertyChanged("price");
               }
           }



           private ObservableCollection<DVD> _dvdList;

           public ObservableCollection<DVD> dvdList
           {
               get { return _dvdList; }
               set
               {
                   _dvdList = value;
                   OnPropertyChanged("dvdList");
               }
           }

           private ObservableCollection<Books> _bookList;

           public ObservableCollection<Books> bookList
           {
               get { return _bookList; }
               set
               {
                   _bookList = value;
                   OnPropertyChanged("bookList");
               }
           }


           private ICommand _orderBookCommand;

           public ICommand orderBookCommand
           {
               get
               {
                   if (_orderBookCommand == null)
                   {

                       _orderBookCommand = new Command(OrderBook, () => true);
                   }

                   return _orderBookCommand;
               }

               set { _orderBookCommand = value; }
           }

           public void OrderBook()
           {
               if (bookList.Where(x => x.id == _id).Count() != 0)
               {
                   price = quantcontrol.OrderBook(_id, _quantity);
                   bookList.Where(x => x.id == _id).First().quantity += _quantity;
                   bookList = new ObservableCollection<Books>(itemcontrol.GetAllBooks());
               }

           }


           private ICommand _orderDvDCommand;

           public ICommand orderDvDCommand
           {
               get
               {
                   if (_orderDvDCommand == null)
                   {

                       _orderDvDCommand = new Command(OrderDvD, () => true);
                   }

                   return _orderDvDCommand;
               }

               set { _orderDvDCommand = value; }
           }

           public void OrderDvD()
           {
               price = quantcontrol.OrderDvd(_id, _quantity);

               if (dvdList.Where(x => x.id == _id).Count() != 0)
               {

                   dvdList.Where(x => x.id == _id).First().quantity += _quantity;
                   dvdList = new ObservableCollection<DVD>(itemcontrol.GetAllDVDs());
               }
           }
    }
}
