using System;
using System.Xml.Linq;
using WordLearning.Shape;

namespace WordLearning.Colors
{
    public class TagColor
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
            get
            {
                return int.Parse(Tag.Element(nameof(Red)).Value);
            }

            set
            {
                Tag.Element(nameof(Red)).Value = value.ToString();
            }
        }

        public int Green
        {
            get
            {
                return int.Parse(Tag.Element(nameof(Green)).Value);
            }

            set
            {
                Tag.Element(nameof(Green)).Value = value.ToString();
            }
        }

        public int Blue
        {
            get
            {
                return int.Parse(Tag.Element(nameof(Blue)).Value);
            }

            set
            {
                Tag.Element(nameof(Blue)).Value = value.ToString();
            }
        }

        public string Meaning
        {
            get
            {
                return Tag.Element(nameof(Meaning)).Value;
            }

            set
            {
                Tag.Element(nameof(Meaning)).Value = value.ToString();
            }
        }

        public WlShape Shape
        {
            get
            {
                return Enum.Parse<WlShape>(Tag.Element(nameof(Shape)).Value);
            }

            set
            {
                Tag.Element(nameof(Shape)).Value = value.ToString();
            }
        }

        public Android.Graphics.Color WlColor
        {
            get
            {
                return Android.Graphics.Color.Rgb(Red, Green, Blue);
            }
        }

        public int this[int index]
        {
            get
            {
                return index switch
                {
                    0 => Red,
                    1 => Green,
                    2 => Blue,
                    _ => throw new IndexOutOfRangeException(),
                };
            }
        }
    }
}
