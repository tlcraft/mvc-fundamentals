using Shared.Models;
using System.Runtime.InteropServices;

namespace Shared.Services
{
    public class WindowsNativeDateService : ICurrentDateService
    {
        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(SystemTime systemTime);

        public string CurrentDate
        {
            get
            {
                var systemTime = new SystemTime();
                GetSystemTime(systemTime);
                return systemTime.ToString();
            }
        }
    }
}
