using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketLocationProvider
{
    public class MarketLocationProvider
    {
        public const string KISTELEK = "Kisteleken";
        public const string DOROZSMA = "Dorozsmán";
        public const string MORAHALOM = "Mórahalmon";
        public const string RUZSA = "Ruzsán";
        private const string NEM = "nem";

        private IDateTimeProvider _dateTimeProvider;

        public MarketLocationProvider(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }


        public string GetMarketLocation()
        {
            var currentDate = _dateTimeProvider.GetNextSunday();
            return GetMarketLocation(currentDate);
        }

        public Dictionary<string, List<DateTime>> GetUpcomingVenues()
        {
            Dictionary<string, List<DateTime>> venues = new Dictionary<string, List<DateTime>>();
            InitVenues(venues);
            var sundays = GetUpcomingSundays();

            foreach (var sunday in sundays)
            {
                string location = GetMarketLocation(sunday);
                AddToVenue(venues, location, sunday);
            }

            return venues;
        }

        private void AddToVenue(Dictionary<string, List<DateTime>> venues, string location, DateTime sunday)
        {
            if (location == NEM)
            {
                return;
            }
            venues[location].Add(sunday);
        }

        private void InitVenues(Dictionary<string, List<DateTime>> venues)
        {
            venues.Add(KISTELEK, new List<DateTime>());
            venues.Add(DOROZSMA, new List<DateTime>());
            venues.Add(MORAHALOM, new List<DateTime>());
            venues.Add(RUZSA, new List<DateTime>());
        }

        private string GetMarketLocation(DateTime date)
        {
            string locationString;


            switch (date.GetWeekOfMonth())
            {
                case 1:
                    locationString = KISTELEK;
                    break;
                case 2:
                    locationString = DOROZSMA;
                    break;
                case 3:
                    locationString = MORAHALOM;
                    break;
                case 4:
                    locationString = RUZSA;
                    break;
                default:
                    locationString = NEM;
                    break;
            }

            return locationString;
        }

        private IEnumerable<DateTime> GetUpcomingSundays()
        {
            List<DateTime> sundays = new List<DateTime>();
            var currentDate = _dateTimeProvider.GetCurrentDate();

            var dt = currentDate.AddDays(DayOfWeek.Sunday - currentDate.DayOfWeek);

            if (DayOfWeek.Sunday <= dt.DayOfWeek)
            {
                dt = dt.AddDays(7);
            }

            for (int i = 0; i < 12; i++)
            {
                sundays.Add(dt);
                dt = dt.AddDays(7);
            }

            return sundays;
        }
    }
}
