namespace MarketLocationProvider
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDate();
        DateTime GetNextSunday();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDate() => DateTime.UtcNow;
        //public DateTime GetCurrentDate() => new DateTime(2022,10,26); //TESTS: nem volt vásár

        public DateTime GetNextSunday()
        {
            var date = DateTime.UtcNow;
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            return date;
        }
    }
}
