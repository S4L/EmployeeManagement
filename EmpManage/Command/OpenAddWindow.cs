using EMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EMS.UI.Command
{
    public class OpenAddWindow: ICommand
    {
        //private MainVM _employeeViewModel;

        //public AddCommand(MainVM viewModel)
        //{
        //    _employeeViewModel = viewModel;
        //}

        private UIService _uiService;

        public OpenAddWindow(UIService service)
        {
            _uiService = service;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //TODO: Add condition to open
        }

        public void Execute(object parameter)
        {
            _uiService.OpenNewEmployeeWindow();
        }
    }
}
