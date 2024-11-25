using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Engine_Proy
{
    public static class Localization2
    {
        private static ResourceManager _rm;

        static Localization2()
        {
            _rm = new ResourceManager("Engine_Proy.Languange.Resource_OL", Assembly.GetEntryAssembly());
        }

        public static string? GetString(string name) 
        {
            return _rm.GetString(name);
        }

        public static void ChangeLanguage (string language)
        {
            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }

    }
}
