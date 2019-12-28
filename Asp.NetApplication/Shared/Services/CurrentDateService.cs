using System;

namespace Shared.Services
{
    public class CurrentDateService : ICurrentDateService
    {
        public string CurrentDate
        {
            get
            {
                return DateTime.Now.ToLongDateString();
            }
        }
    }
}
