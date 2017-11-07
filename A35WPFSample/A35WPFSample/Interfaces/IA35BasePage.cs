using A35WPFSample.Views;
using System;

namespace A35WPFSample.Interfaces
{
    public interface IA35BasePage
    {
        event EventHandler<IA35BasePage> changePage;
    }
}
