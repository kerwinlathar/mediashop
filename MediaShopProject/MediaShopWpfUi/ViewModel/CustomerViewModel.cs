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
    public class CustomerViewModel : AbstractViewModel
    {
        private CustomerController custcontrol;


        public CustomerViewModel()
        {
            this.custcontrol = new CustomerController(new ModelMediaShopData());
            customerList = new ObservableCollection<Customer>(custcontrol.GetAllCustomers());
        }

        public CustomerViewModel(CustomerController custcontrol)
        {
            this.custcontrol = custcontrol;
            customerList = new ObservableCollection<Customer>(custcontrol.GetAllCustomers());
        }

        private ObservableCollection<Customer> _customerList;

        public ObservableCollection<Customer> customerList
        {
            get { return _customerList; }
            set
            {
                _customerList = value;
                OnPropertyChanged("customerList");
            }
        }

        private int _id;

        public int id
        {
            get { return _id; }

            set
            {
                if (value == _id)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged("id");
            }
        }

        private string _name;

        public string name
        {
            get { return _name; }

            set
            {
                if (value == _name)
                {
                    return;
                }

                _name = value;
                OnPropertyChanged("name");
            }
        }

        private string _password;

        public string password
        {
            get { return _password; }

            set
            {
                if (value == _password)
                {
                    return;
                }

                _password = value;
                OnPropertyChanged("password");
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
            Customer toadd = new Customer() { id = _id, name= _name, password = _password};

            custcontrol.AddCustomer(toadd);
            customerList = new ObservableCollection<Customer>(custcontrol.GetAllCustomers());

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
            custcontrol.RemoveCustomer(_id);
            customerList = new ObservableCollection<Customer>(custcontrol.GetAllCustomers());
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
            Customer toupp = new Customer() { id = _id, name = _name, password = _password };

            custcontrol.UpdateCustomer(_id,toupp);
            customerList = new ObservableCollection<Customer>(custcontrol.GetAllCustomers());
        }
    }
}
