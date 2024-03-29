﻿using System.Xml.Linq;
using WordLearning.Domain.Utility;

namespace WordLearning.Domain.Colors
{
    public static class ThemeColor
    {
        public const int DefaultRed = 0;


        public const int DefaultGreen = 200;


        public const int DefaultBlue = 0;


        static ThemeColor()
        {
            Theme = WlUtility.RootElement.Element(nameof(ThemeColor));
        }

        public static Android.Graphics.Color Color => Android.Graphics.Color.Rgb(Red, Green, Blue);

        public static Android.Graphics.Color DarkColor => Android.Graphics.Color.Argb(Color.A * 4 / 5, Color.R, Color.G, Color.B);

        private static XElement Theme { get; }

        public static int Red
        {
            get => int.Parse(Theme.Element(nameof(Red)).Value);

            set => Theme.Element(nameof(Red)).Value = value.ToString();
        }

        public static int Green
        {
            get => int.Parse(Theme.Element(nameof(Green)).Value);

            set => Theme.Element(nameof(Green)).Value = value.ToString();
        }

        public static int Blue
        {
            get => int.Parse(Theme.Element(nameof(Blue)).Value);

            set => Theme.Element(nameof(Blue)).Value = value.ToString();
        }


        public static XElement GetDefaultThemeColorElement()
        {
            return new(nameof(ThemeColor),
                new XElement(nameof(Red), DefaultRed),
                new XElement(nameof(Green), DefaultGreen),
                new XElement(nameof(Blue), DefaultBlue)
    );
        }

    }
}
