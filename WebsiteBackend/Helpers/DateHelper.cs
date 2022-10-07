using System;

namespace WebsiteBackend.Helpers;
public static class DateHelper
{
    private static TimeZoneInfo TimeZone => TimeZoneInfo
        .FindSystemTimeZoneById("E. South America Standard Time");

    public static DateTime BrazilDateTimeNow()
        => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZone);
}