using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketLocationProvider
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDate();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDate() => DateTime.UtcNow;
        //public DateTime GetCurrentDate() => new DateTime(2022,10,26); //TESTS: nem volt vásár
    }
}
