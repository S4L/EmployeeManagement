using EmpManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmpManage.Command
{
    public class CreateEmployeeCmd : ICommand
    {
        private NewEmployeeVM _newEmployeeViewModel;

        public CreateEmployeeCmd(NewEmployeeVM viewModel)
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
