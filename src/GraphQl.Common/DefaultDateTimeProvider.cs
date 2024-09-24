using GraphQl.Abstraction;

namespace GraphQl.Common;

public class DefaultDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}
