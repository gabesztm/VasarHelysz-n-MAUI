using MarketLocationProvider;

namespace VasarMAUI
{
    internal class NextEventsViewModel
    {
        private readonly MarketLocationProvider.MarketLocationProvider _marketLocationProvider = new MarketLocationProvider.MarketLocationProvider(new DateTimeProvider());
        public List<DateTime> KistelekDates { get; set; }
        public List<DateTime> DorozsmaDates { get; set; }
        public List<DateTime> MorahalomDates { get; set; }
        public List<DateTime> RuzsaDates { get; set; }

        public NextEventsViewModel()
        {
            UpdateDates();
        }

        internal void UpdateDates()
        {
            var venues = _marketLocationProvider.GetUpcomingVenues();

            KistelekDates = venues[MarketLocationProvider.MarketLocationProvider.KISTELEK];
            DorozsmaDates = venues[MarketLocationProvider.MarketLocationProvider.DOROZSMA];
            MorahalomDates = venues[MarketLocationProvider.MarketLocationProvider.MORAHALOM];
            RuzsaDates = venues[MarketLocationProvider.MarketLocationProvider.RUZSA];
        }
    }
}
