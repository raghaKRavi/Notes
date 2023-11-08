using Notes.Application.Common.Interfaces.Services;

namespace Notes.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}