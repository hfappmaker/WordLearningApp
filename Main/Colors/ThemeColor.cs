using System;
using System.Xml.Linq;
using WordLearning.Utility;

namespace WordLearning.Colors
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

        public static Android.Graphics.Color Color
        {
            get
            {
                return Android.Graphics.Color.Rgb(Red, Green, Blue);
            }
        }

        public static Android.Graphics.Color DarkColor
        {
            get
            {
                return Android.Graphics.Color.Argb(Color.A * 4 / 5, Color.R, Color.G, Color.B);
            }
        }

        private static XElement Theme { get; }

        public static int Red
        {
            get
            {
                return int.Parse(Theme.Element(nameof(Red)).Value);
            }

            set
            {
                Theme.Element(nameof(Red)).Value = value.ToString();
            }
        }

        public static int Green
        {
            get
            {
                return int.Parse(Theme.Element(nameof(Green)).Value);
            }

            set
            {
                Theme.Element(nameof(Green)).Value = value.ToString();
            }
        }

        public static int Blue
        {
            get
            {
                return int.Parse(Theme.Element(nameof(Blue)).Value);
            }

            set
            {
                Theme.Element(nameof(Blue)).Value = value.ToString();
            }
        }

    }
}
