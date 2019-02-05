using EMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EMS.UI.Command
{
    public class AddEmployee : ICommand
    {
        private UIService _uiService;

        public AddEmployee(UIService service)
        {
            _uiService = service;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _uiService.AddEmployee();
        }
    }
}
