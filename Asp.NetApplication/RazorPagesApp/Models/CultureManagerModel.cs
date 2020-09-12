using System.Collections.Generic;
using System.Globalization;

namespace Models
{
    /// <summary>
    /// The CultureManagerModel is used to determine which user selected language is currently set for localization purposes. It also contains the full set of supported languages.
    /// <list type="bullet">
    /// <item>
    /// <term>CurrentUICulture</term>
    /// <description>Gets the value of the currently set UI culture.</description>
    /// </item>
    /// <item>
    /// <term>SupportedCultures</term>
    /// <description>Gets the list of supported UI cultures.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class CultureManagerModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
