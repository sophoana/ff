using FF.Contracts.Service;
using System;

namespace FF.Service
{
    public class DateTimeService : BaseService, IDateTimeService
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
