namespace Cds.TestDashboard.Core.Helpers
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="DateTimeHelperExtensions"/>.
    /// </summary>
    public static class DateTimeHelperExtensions
    {
        /// <summary>
        /// Method to get <see cref="DateTime"/> from <see cref="long"/> timestamp.
        /// </summary>
        /// <param name="html">Instance of the <see cref="HtmlHelper"/>.</param>
        /// <param name="timestamp">The <see cref="long"/> to convert.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static DateTime TimeStampToDateTime(this HtmlHelper html, long timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(timestamp).ToLocalTime();
            return dateTime;
        }
    }
}
