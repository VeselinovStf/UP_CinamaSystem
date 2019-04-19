using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAPI.DateTimeWraper
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}