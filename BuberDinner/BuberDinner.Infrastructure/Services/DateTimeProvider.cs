using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
