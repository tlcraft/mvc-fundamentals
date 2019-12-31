using System.Runtime.InteropServices;

namespace Shared.Services
{
    public class CurrentDateServiceFactory : ICurrentDateServiceFactory
    {
        public ICurrentDateService GetCurrentDateService()
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
