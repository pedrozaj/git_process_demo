using A35WPFSample.Interfaces;
using A35WPFSample.Models;
using A35WPFSample.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace A35WPFSample.Views
{
    public partial class MainPage : A35BasePage, IA35BasePage
    {
        //CONSTRUCTOR
        public MainPage()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel(samIsCoolAndHereHeIs); //just an example of passing an event to a constructor, not necessary and rare
            base.DataContext = _mainViewModel;
            pageLoaded += _mainViewModel.OnPageLoaded;
        }


        //MEMBERS
        MainViewModel _mainViewModel;
        public event EventHandler<object> pageLoaded;
        public event EventHandler<PersonModel> samIsCoolAndHereHeIs;
        public event EventHandler<IA35BasePage> changePage;


        //LIFE CYCLE OVERRIDES
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pageLoaded?.Invoke(this, null);
        }


        //BUTTON CLICK HANDLERS
        private void btnRemovePerson_Click(object sender, RoutedEventArgs e)
        {
            if(_mainViewModel.IsSamCool()) //duh, always going to fire ;)
            {
                samIsCoolAndHereHeIs?.Invoke(sender, new PersonModel("Sam", "Rosewall", 34));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changePage?.Invoke(sender, new PageTwo());
        }
    }
}
