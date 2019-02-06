using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EMS.UI.Command
{
    public class OpenUpdateWindow : ICommand
    {
        private UIService _uiService;
        public OpenUpdateWindow(UIService service)
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
            _uiService.OpenUpdateWindow();
        }
    }
}
