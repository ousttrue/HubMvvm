using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace HubMvvm.Views
{
    public class NavigationPage: Page
    {
        HubMvvm.Common.NavigationHelper m_navigationHelper;
        public HubMvvm.Common.NavigationHelper NavigationHelper
        {
            get { return m_navigationHelper; }
        }

        public NavigationPage()
        {
            m_navigationHelper = new HubMvvm.Common.NavigationHelper(this);
            m_navigationHelper.LoadState += NavigationHelper_LoadState;
            m_navigationHelper.SaveState += NavigationHelper_SaveState;
        }

        private async void NavigationHelper_LoadState(object sender, HubMvvm.Common.LoadStateEventArgs e)
        {
        }

        private void NavigationHelper_SaveState(object sender, HubMvvm.Common.SaveStateEventArgs e)
        {
        }

        #region NavigationHelper の登録
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.m_navigationHelper.OnNavigatedTo(e);
            if (e.Parameter!=null)
            {
                this.DataContext = e.Parameter;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.m_navigationHelper.OnNavigatedFrom(e);
        }
        #endregion
    }
}
