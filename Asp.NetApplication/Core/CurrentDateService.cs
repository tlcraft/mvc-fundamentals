using System;

namespace Core
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
