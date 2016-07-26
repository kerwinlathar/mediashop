using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaShopWpfUi.ViewModel
{
    public class NavigationViewModel : AbstractViewModel
    {
        private string _pageLocation;

        public string pageLocation
        {
            get { return _pageLocation; }

            set
            {
                _pageLocation = value;
                OnPropertyChanged("pageLocation");
            }
        }

        public NavigationViewModel()
        {
            pageLocation = "Pages/HomePage.xaml";
        }

        private ICommand _navigateCommand;

        public ICommand navigateCommand
        {
            get
            {
                if (_navigateCommand == null)
                {

                    _navigateCommand = new CommandPram<string>(Navigate, CanNavigate);
                }

                return _navigateCommand;
            }

            set { _navigateCommand = value; }
        }

        private void Navigate(string whereToGo)
        {
            var vm = App.Current.MainWindow.DataContext as NavigationViewModel;
            vm.pageLocation = "Pages/" + whereToGo + ".xaml";
        }

        private bool CanNavigate(string wheretogo)
        {
            return true;
        }
    }
}
