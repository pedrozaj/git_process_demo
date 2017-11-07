using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace A35WPFSample.Views
{
    public partial class A35BasePage : Page
    {
        public new object DataContext
        {
            get { return base.DataContext; }
            set { base.DataContext = value; }
        }
    }
}
