using System.Collections.Generic;
using System.Globalization;

namespace Shared.Models
{
    public class CultureManagerModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
