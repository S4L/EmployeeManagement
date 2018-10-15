using EmMana.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmMana.WPF.Command
{
    class CreateEmployeeCommand : ICommand
    {
        private NewEmployeeViewModel _newEmployeeViewModel;

        public CreateEmployeeCommand(NewEmployeeViewModel viewModel)
        {
            _newEmployeeViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _newEmployeeViewModel.CanCreate();
        }

        public void Execute(object parameter)
        {
            _newEmployeeViewModel.SaveChanges();
        }
    }
}
