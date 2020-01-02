using Shared.Models;
using System.Runtime.InteropServices;

namespace Shared.Services
{
    public class WindowsNativeDateService : ICurrentDateService
    {
        [DllImport("kernel32.dll")]
        static extern void GetLocalTime(SystemTime systemTime);

        public string CurrentDate
        {
            get
            {
                var systemTime = new SystemTime();
                GetLocalTime(systemTime);
                return systemTime.ToString();
            }
        }
    }
}
