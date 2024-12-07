using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Localitation {
    public static class LocalizationManager 
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _localizations = new()
    {
        {
            "en", new Dictionary<string, string>
            {
                { "play_button", "Play" },
                { "localization_button", "Localization" },
                { "main_menu_title", "SIMIOJUEGO" }
            }
        },
        {
            "es", new Dictionary<string, string>
            {
                { "play_button", "Jugar" },
                { "localization_button", "Localización" },
                { "main_menu_title", "SIMIOJUEGO" }
            }
        }
    };

        public static string CurrentLanguage { get; private set; } = "es";

        public static void SetLanguage(string language)
        {
            if (_localizations.ContainsKey(language))
            {
                CurrentLanguage = language;
            }
        }

        public static string GetLocalizedText(string key)
        {
            return _localizations.TryGetValue(CurrentLanguage, out var translations) && translations.ContainsKey(key)
                ? translations[key]
                : key; // Devuelve la clave si no encuentra la traducción
        }
    }
}

