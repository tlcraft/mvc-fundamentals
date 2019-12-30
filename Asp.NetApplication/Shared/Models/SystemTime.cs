using System.Runtime.InteropServices;

namespace Shared.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public class SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Milsecond;

        public override string ToString()
        {
            return $"{Month} {Day}, {Year}";
        }
    }
}