using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Infrastructure.Extensions;

namespace Infrastructure.Extensions
{
    public static class PersianDateTimeUtility
    {
        private static List<string> PersianMonths = new List<string>()
        {
            "ماه های سال",
            "فروردین",
            "اردیبهشت",
            "خرداد",

            "تیـر",
            "مـرداد",
            "شهریور",

            "مهر",
            "آبان",
            "آذر",

            "دی",
            "بهمن",
            "اسفند",

        };

        public static string GetMonthName(short MonthNo) => PersianMonths[MonthNo];

        public static bool IsPersianDate(this string PersianStr)
        {
            try
            {
                var StrNumbers = PersianStr.Fa2En()
                    .Split(new string[] { "/", "\\", "|", ",", ".", "-", " " },
                        StringSplitOptions.RemoveEmptyEntries);

                if (StrNumbers == null || !StrNumbers.Any() || StrNumbers.Length < 3)
                    return false;

                var Numbers = StrNumbers.Select(x => Convert.ToInt32(x)).ToList();

                if (Numbers == null || !Numbers.Any() || Numbers.Count < 3)
                    return false;

                if (Numbers[1] < 1 || Numbers[1] > 12)
                    return false;

                if (Numbers[2] < 1 || Numbers[2] > 31)
                    return false;

                var p = new PersianCalendar();
                var r = p.ToDateTime(Numbers[0], Numbers[1], Numbers[2], 0, 0, 0, 0);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ToPersianDate(this string PersianStr)
        {
            var StrNumbers = PersianStr
                .Split(new string[] { "/", "\\", ",", "|", "." },
                    StringSplitOptions.RemoveEmptyEntries);

            var IntNumbers = StrNumbers
                .Select(x => x.Fa2En())
                .Where(x => int.TryParse(x, out int tmp))
                .Select(x => int.Parse(x))
                .ToArray();

            var p = new PersianCalendar();

            return p.ToDateTime(IntNumbers[0], IntNumbers[1], IntNumbers[2], 0, 0, 0, 0);
        }

        public static string ToPersianDate(this DateTime Date)
        {
            var persian = new PersianCalendar();

            var Year = persian.GetYear(Date);
            var Month = persian.GetMonth(Date);
            var Day = persian.GetDayOfMonth(Date);

            return
                string
                    .Concat(Year, "/",
                        Month.ToString("D2"), "/",
                        Day.ToString("D2"))
                    .En2Fa();
        }

        public static string ToPersianDate(this DateTime Date, bool ShowLongMode)
        {

            var persian = new PersianCalendar();
            var Year = persian.GetYear(Date);
            var Day = persian.GetDayOfMonth(Date);
            var Month = persian.GetMonth(Date);
            if (ShowLongMode)
            {
                return
                    string
                        .Concat(Year, "/",
                            Month.ToString("D2"), "/",
                            Day.ToString("D2"))
                        .En2Fa();
            }
            else
            {
                return
                    string
                        .Concat(Day.ToString(),
                            " ",
                            PersianMonths[Month],
                            " ",
                            Year)
                        .En2Fa();

            }

        }

    }
}
