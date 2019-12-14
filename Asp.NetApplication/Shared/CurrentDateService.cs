using System;

namespace Shared
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
