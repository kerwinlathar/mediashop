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
    public class BookViewModel: AbstractViewModel
    {
        
        private ItemController itemcontrol;


           public BookViewModel()
           {
               this.itemcontrol= new ItemController(new ModelMediaShopData());
               bookList = new ObservableCollection<Books>(itemcontrol.GetAllBooks());
           }

        public BookViewModel(ItemController itemcontrol)
           {
               this.itemcontrol = itemcontrol;
                bookList = new ObservableCollection<Books>(itemcontrol.GetAllBooks());
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

        private string _author;

        public string author
        {
            get { return _author; }
            set
            {
                if (value == _author)
                {
                    return;
                }
                _author = value;
                OnPropertyChanged("author");
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

        private ICommand _addCommand;

        public ICommand addCommand
        {
            get
            {
                if (_addCommand == null)
                {

                    _addCommand = new Command(Add, () => true);
                }

                return _addCommand;
            }

            set { _addCommand = value; }
        }

        public void Add()
        {
            Books toadd = new Books() { id = _id, author = _author, title = _title, price = _price, quantity = 0 };

            itemcontrol.AddBook(toadd);
            bookList = new ObservableCollection<Books>(itemcontrol.GetAllBooks());

        }

        private ICommand _removeCommand;

        public ICommand removeCommand
        {
            get
            {
                if (_removeCommand == null)
                {

                    _removeCommand = new Command(Remove, () => true);
                }

                return _removeCommand;
            }

            set { _removeCommand = value; }
        }


        public void Remove()
        {
            itemcontrol.RemoveBook(_id);
            bookList = new ObservableCollection<Books>(itemcontrol.GetAllBooks());
        }

        private ICommand _updateCommand;

        public ICommand updateCommand
        {
            get
            {
                if (_updateCommand == null)
                {

                    _updateCommand = new Command(Update, () => true);
                }

                return _updateCommand;
            }

            set { _updateCommand = value; }
        }

        public void Update()
        {
            Books toup = new Books() { id = _id, author = _author, title = _title, price = _price, quantity = 0 };

            itemcontrol.UpdateBook(_id, toup);
            bookList = new ObservableCollection<Books>(itemcontrol.GetAllBooks());
        }
    }
}
