using A35WPFSample.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace A35WPFSample.ViewModels
{
    public class PageTwoViewModel : BaseViewModel
    {
        //CONSTRUCTOR
        public PageTwoViewModel()
        {
            _showMessageWithParamsCommand = new RelayCommand(ShowMessage, param => IsAllowedToShowPopups);
        }


        //MEMBERS
        private bool _isAllowedToShowPopups = true;
        private ICommand _showMessageWithParamsCommand;
        

        //PROPERTIES
        public bool IsAllowedToShowPopups
        {
            get { return _isAllowedToShowPopups; }
            set { _isAllowedToShowPopups = value; }
        }
        public ICommand ShowMessageWithParamsCommand
        {
            get { return _showMessageWithParamsCommand; }
            set
            {
                _showMessageWithParamsCommand = value; OnPropertyChanged();
            }
        }
        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }
    }
}
