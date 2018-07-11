using System;
using FF.Contracts.Service;

namespace FF.Data
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
