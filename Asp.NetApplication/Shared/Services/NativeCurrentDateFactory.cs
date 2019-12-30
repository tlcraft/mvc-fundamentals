using System.Runtime.InteropServices;

namespace Shared.Services
{
    public class NativeCurrentDateFactory : INativeCurrentDateFactory
    {
        public ICurrentDateService GetNativeCurrentDateService()
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if(isWindows)
            {
                return new WindowsNativeDateService();
            }
            else
            {
                return new CurrentDateService();
            }
        }
    }
}
