using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaShopWpfUi.ViewModel
{
    public class PagesLocationViewModel : AbstractViewModel
    {
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
