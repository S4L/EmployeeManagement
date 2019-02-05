using EMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EMS.UI.Command
{
    public class UpdateEmployee : ICommand
    {
        private UpdateEmployeeVM _viewModel;
        public UpdateEmployee(UpdateEmployeeVM viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true; //TODO: Add conditions for updating employee
        }

        public void Execute(object parameter)
        {
            //_viewModel.UpdateChanges();
        }
    }
}
