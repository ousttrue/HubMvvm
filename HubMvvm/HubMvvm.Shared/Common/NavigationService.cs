using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HubMvvm.Common
{
    public class NavigationService
    {
        public void Naviagte(Type sourcePage)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(sourcePage);
        }

        public void Navigate(Type sourcePage, object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(sourcePage, parameter);
        }

        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            frame.GoBack();
        }

        private NavigationService()
        { }

        public static NavigationService Instance = new NavigationService();
    }
}
