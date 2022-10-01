using System;
using System.Xml.Linq;
using WordLearning.Domain.Shape;

namespace WordLearning.Domain.Colors
{
    public class TagColor : Java.Lang.Object
    {
        public static Android.Graphics.Color DefaultTagColor { get; } = Android.Graphics.Color.Rgb(0, 200, 0);

        public static WlShape DefaultShape { get; } = WlShape.Square;

        public TagColor(XElement tag)
        {
            Tag = tag;
        }

        private XElement Tag { get; }

        public int Red
        {
            get => int.Parse(Tag.Element(nameof(Red)).Value);

            set => Tag.Element(nameof(Red)).Value = value.ToString();
        }

        public int Green
        {
            get => int.Parse(Tag.Element(nameof(Green)).Value);

            set => Tag.Element(nameof(Green)).Value = value.ToString();
        }

        public int Blue
        {
            get => int.Parse(Tag.Element(nameof(Blue)).Value);

            set => Tag.Element(nameof(Blue)).Value = value.ToString();
        }

        public string Meaning
        {
            get => Tag.Element(nameof(Meaning)).Value;

            set => Tag.Element(nameof(Meaning)).Value = value.ToString();
        }

        public WlShape Shape
        {
            get => WlShape.Parse(Tag.Element(nameof(Shape)).Value);

            set => Tag.Element(nameof(Shape)).Value = value.Id.ToString();
        }

        public Android.Graphics.Color WlColor => Android.Graphics.Color.Rgb(Red, Green, Blue);

        public int this[int index] => index switch
        {
            0 => Red,
            1 => Green,
            2 => Blue,
            _ => throw new IndexOutOfRangeException(),
        };


        public static XElement GetDefaultTagColorElement()
        {
            return new(nameof(TagColor),
                new XElement(nameof(Red), DefaultTagColor.R),
                new XElement(nameof(Green), DefaultTagColor.G),
                new XElement(nameof(Blue), DefaultTagColor.B),
                new XElement(nameof(Meaning), string.Empty),
                new XElement(nameof(Shape), DefaultShape)
         );
        }
    }
}
