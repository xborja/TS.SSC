using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TS.SSC.Portal.Services
{
    public class Utils
    {
        public static int WeeksInYear(DateTime date)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}