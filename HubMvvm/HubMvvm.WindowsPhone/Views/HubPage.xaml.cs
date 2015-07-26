using Windows.ApplicationModel.Resources;
using Windows.Graphics.Display;

namespace HubMvvm.Views
{
    public sealed partial class HubPage : Common.NavigationPage
    {
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public HubPage()
        {
            this.InitializeComponent();

            // ハブは縦向きでのみサポートされています
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }
    }
}
