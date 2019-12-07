using System;

namespace Core
{
    public class SystemTime : ISystemTime
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
