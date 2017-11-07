using System;
using A35WPFSample.Views;
using System.Windows.Controls;
using A35WPFSample.Helpers;
using System.Windows;
using A35WPFSample.Interfaces;

namespace A35WPFSample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //CONSTRUCTOR
        public MainWindowViewModel()
        {
            MainPage mainPage = new MainPage();
            DisplayPage = mainPage;
            mainPage.changePage += OnChangePage;
        }


        //MEMBERS
        private Page _displayPage;


        //PROPERTIES
        public Page DisplayPage
        {
            get
            {
                return _displayPage;
            }
            set
            {
                if (_displayPage == value)
                {
                    return;
                }
                
                _displayPage = value;
                OnPropertyChanged();
            }
        }


        //EVENT HANDLING
        public void OnChangePage(object sender, IA35BasePage newPage)
        {
            ((IA35BasePage)DisplayPage).changePage -= OnChangePage;

            DisplayPage = (Page)newPage;
            newPage.changePage += OnChangePage;
        }
    }
}
