using Application.Contracts.Infrastructure;

namespace Infrastructures.TimeProvider;

public class DateTimeService : IDateTime
{
    public DateTime IranNow => TimeZoneInfo
        .ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time"));
}