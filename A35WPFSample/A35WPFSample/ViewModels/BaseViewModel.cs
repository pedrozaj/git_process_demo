using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace A35WPFSample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

        }

        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
