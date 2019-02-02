using EMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EMS.UI.Command
{
    public class OpenNewEmployeeViewCmd: ICommand
    {
        private MainVM _employeeViewModel;

        public OpenNewEmployeeViewCmd(MainVM viewModel)
        {
            _employeeViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //TODO: Add condition to open
        }

        public void Execute(object parameter)
        {
            _employeeViewModel.OpenNewEmployeeWindow();
        }
    }
}
