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
        private UIService _uiService;
        public UpdateEmployee(UIService service)
        {
            _uiService = service;
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
