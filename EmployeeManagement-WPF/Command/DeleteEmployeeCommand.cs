using EmMana.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmMana.WPF.Command
{
    public class DeleteEmployeeCommand: ICommand
    {
        private EmployeeViewModel _viewmodel;

        public DeleteEmployeeCommand(EmployeeViewModel viewModel)
        {
            _viewmodel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewmodel.DeleteSelectedEmployee();
        }
    }
}
