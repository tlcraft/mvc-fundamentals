using System.Collections.Generic;
using System.Globalization;

namespace Models
{
    public class CultureManagerModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
