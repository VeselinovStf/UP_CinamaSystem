using System;

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