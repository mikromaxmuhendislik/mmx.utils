using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class DateTimeHelpers
    {
        public static DateTime DefaultIfEmpty(this DateTime date)
        {
            if (date.Year < 1899)
            {
                return new DateTime(1899, 12, 31);
            }
            return date;
        }
        public static DateTime Now => DateTime.Now;
        /// <summary>
        /// Returns totaldays for given date from unix epoch.
        /// <br/>
        /// <strong>Epoch: 1970-1-1</strong>
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static double GetTotalDaysFromEpoch(this DateTime date) {
            return (date - DateTime.UnixEpoch).TotalDays;
        }
        /// <summary>
        /// Adds given days to epoch time.
        /// <br/>
        /// <strong>Epoch: 1970-1-1</strong>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AddDaysToEpoch(this double value) {
            return DateTime.UnixEpoch.AddDays(value);
        }
    }
}
