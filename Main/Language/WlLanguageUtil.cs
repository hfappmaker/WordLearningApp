using System.Collections.Generic;

namespace WordLearning.Language
{
    public static class WlLanguageUtil
    {
        private static IReadOnlyDictionary<WlLanguage, Java.Util.Locale> LocaleDictionary { get; } = new Dictionary<WlLanguage, Java.Util.Locale>()
        {
            {WlLanguage.English,      Java.Util.Locale.English},
            {WlLanguage.日本語,        Java.Util.Locale.Japanese},
            {WlLanguage.简体中文,      Java.Util.Locale.SimplifiedChinese},
            {WlLanguage.繁體中文,      Java.Util.Locale.TraditionalChinese},
            {WlLanguage.Deutsch,      Java.Util.Locale.Germany},
            {WlLanguage.Français,     Java.Util.Locale.French},
            {WlLanguage.한국어,         Java.Util.Locale.Korean},
            {WlLanguage.русский,  new Java.Util.Locale("rus")},
            {WlLanguage.इंडिया,     new Java.Util.Locale("ind")},
            {WlLanguage.None,         null}
        };



        public static Java.Util.Locale GetLocale(WlLanguage language)
        {
            return LocaleDictionary[language];
        }


        public static WlLanguage GetLocaleId()
        {
            string defaultlanguage;
            string country;
            WlLanguage wlLanguage;
            Dictionary<string, WlLanguage> languagedict = new Dictionary<string, WlLanguage>()
            {
                { "ja",WlLanguage.日本語},
                { "en",WlLanguage.English },
                { "zh",WlLanguage.简体中文 },
                { "de",WlLanguage.Deutsch },
                { "fr",WlLanguage.Français },
                { "ko",WlLanguage.한국어},
                { "ru",WlLanguage.русский},
                { "in",WlLanguage.English }
            };

            // ロケールの取得
            Java.Util.Locale defaultLocale = Java.Util.Locale.GetDefault(Java.Util.Locale.Category.Display);
            defaultlanguage = defaultLocale.Language;
            country = defaultLocale.Country;

            if (languagedict.ContainsKey(defaultlanguage))
            {
                wlLanguage = languagedict[defaultlanguage];
                if (wlLanguage == WlLanguage.简体中文)
                {
                    if (country.Equals("TW") || country.Equals("HK"))
                    {
                        wlLanguage = WlLanguage.繁體中文;
                    }
                }
            }
            else
            {
                wlLanguage = WlLanguage.English;
            }

            return wlLanguage;
        }


        private static WlLanguage? _currentLanguage;
        public static WlLanguage CurrentLanguage
        {
            get
            {
                if (_currentLanguage == null)
                {
                    _currentLanguage = WlLanguageUtil.GetLocaleId();
                }

                return _currentLanguage.Value;
            }
        }

        public static Java.Util.Locale LocaleWord { get; set; } = Java.Util.Locale.English;
        public static Java.Util.Locale LocaleMeaning { get; set; } = Java.Util.Locale.Japan;
    }
}
