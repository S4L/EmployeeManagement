using EMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EMS.UI.Command
{
    public class DeleteEmployeeCmd : ICommand
    {
        private MainVM _viewmodel;

        public DeleteEmployeeCmd(MainVM viewModel)
        {
            _viewmodel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (MainVM.SelectedEmployee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            _viewmodel.DeleteSelectedEmployee();
        }
    }
}
