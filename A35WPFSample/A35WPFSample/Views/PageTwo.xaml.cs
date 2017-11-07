using A35WPFSample.Interfaces;
using System;
using System.Windows.Controls;

namespace A35WPFSample.Views
{
    /// <summary>
    /// Interaction logic for PageTwo.xaml
    /// </summary>
    public partial class PageTwo : A35BasePage, IA35BasePage
    {
        //CONSTRUCTOR
        public PageTwo()
        {
            InitializeComponent();
        }


        //MEMBERS
        public event EventHandler<IA35BasePage> changePage;


        //STORYBOARD CALLBACKS
        private void Storyboard_Completed(object sender, EventArgs e)
        {

        }
        

        //BUTTON LISTENERS
        private void btnMainPagePlease_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            changePage?.Invoke(sender, new MainPage());
        }
    }
}
