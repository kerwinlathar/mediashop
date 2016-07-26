using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaShopLibary;
using System.Collections.ObjectModel;

namespace MediaShopWpfUi.ViewModel
{
    public class DvdViewModel: AbstractViewModel
    {
        private ItemController itemcontrol;


           public DvdViewModel()
           {
               this.itemcontrol= new ItemController(new ModelMediaShopData());
               dvdList = new ObservableCollection<DVD>(itemcontrol.GetAllDVDs());
           }

        public DvdViewModel(ItemController itemcontrol)
           {
               this.itemcontrol = itemcontrol;
               dvdList = new ObservableCollection<DVD>(itemcontrol.GetAllDVDs()); 
           }
        
        private int _id;

        public int id
        {
            get { return _id; }

            set
            {
                if(value == _id)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged("id");
            }
        }

        private string _title;

        public string title
        {
            get { return _title; }
            set 
            {
                if (value == _title)
                {
                    return;
                }
                _title = value;
                OnPropertyChanged("title");
            }
        }

        private string _director;

        public string director
        {
            get { return _director; }
            set
            {
                if (value == _director)
                {
                    return;
                }
                _director = value;
                OnPropertyChanged("director");
            }
        }

        private decimal _price;

        public decimal price
        {
            get { return _price; }
            set
            {
                if (value == _price)
                {
                    return;
                }
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

         private ICommand _addCommand;

        public ICommand addCommand
        {
            get
            {
                if (_addCommand == null)
                {

                    _addCommand = new Command(Add, ()=>true);
                }

                return _addCommand;
            }

            set { _addCommand = value; }
        }

        public void Add()
        {
            DVD toadd = new DVD() { id = _id, director = _director, title = _title, price = _price, quantity = 0 };

            itemcontrol.AddDvd(toadd);
            dvdList = new ObservableCollection<DVD>(itemcontrol.GetAllDVDs());

        }

        private ICommand _removeCommand;

        public ICommand removeCommand
        {
            get
            {
           if (_removeCommand == null)
                {

                    _removeCommand = new Command(Remove, ()=> true);
                }

                return _removeCommand;
            }

            set { _removeCommand = value; }
        }

       
        public void Remove()
        {
            itemcontrol.RemoveDvds(_id);
            dvdList = new ObservableCollection<DVD>(itemcontrol.GetAllDVDs());
        }

        private ICommand _updateCommand;

        public ICommand updateCommand
       {
            get
            {
                if (_updateCommand == null)
                {

                    _updateCommand = new Command(Update, ()=> true);
                }

                return _updateCommand;
            }

           set { _updateCommand = value; }
        }

        public void Update()
        {
            DVD toup = new DVD() { id = _id, director = _director, title = _title, price = _price, quantity = 0 };

            itemcontrol.UpdateDvds(_id, toup);
            dvdList = new ObservableCollection<DVD>(itemcontrol.GetAllDVDs());
        }

                   
    }
}
