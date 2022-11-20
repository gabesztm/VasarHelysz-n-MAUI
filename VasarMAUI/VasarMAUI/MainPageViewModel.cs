using MarketLocationProvider;

namespace VasarMAUI
{
    internal class MainPageViewModel
    {
        private readonly MarketLocationProvider.MarketLocationProvider _marketLocationProvider = new MarketLocationProvider.MarketLocationProvider(new DateTimeProvider());
        public string ThisWeekMessage { get; set; }
        public string ImageLocation { get; set; }

        public MainPageViewModel()
        {
            UpdateMessage();
        }

        internal void UpdateMessage()
        {
            string locationMessage = _marketLocationProvider.GetMarketLocation();

            ThisWeekMessage = $"Ezen a héten {locationMessage} lesz vásár";

            ImageLocation = locationMessage.Contains("nem", StringComparison.InvariantCultureIgnoreCase) ?
                "no_vasar_uj.png" :
                "vasar_uj.png";
        }
    }
}
