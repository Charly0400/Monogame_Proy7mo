using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System;

namespace SandBoxMG.Content.Code.Localitation {
    public static class LocalizationManager
    {
        public enum Language
        {
            ENG = 0,
            ESP = 1,
        }

        private static Language _currentLanguage = Language.ESP; 
        private static Dictionary<string, string[]> _textDictionary = new Dictionary<string, string[]>
        {
            { "Play", new string[] { "        Play", "      Jugar" } },
            { "Localization", new string[] { " Localization", " Localizacion" } },
            { "Title", new string[] { "  MONOGAME  \n THE GAME", "  SIMIOJUEGO  \nEL JUEGO" } }
        };

        public static void SetLanguage(Language language)
        {
            _currentLanguage = language;
        }

        public static string GetLocalizedText(string key)
        {
            if (_textDictionary.TryGetValue(key, out string[] translations))
            {
                return translations[(int)_currentLanguage];
            }

            Debug.WriteLine($"Advertencia: Clave '{key}' no encontrada en el diccionario de localización.");
            return key;
        }

        public static void ToggleLanguage()
        {
            _currentLanguage = _currentLanguage == Language.ENG ? Language.ESP : Language.ENG;
        }
    }
}

