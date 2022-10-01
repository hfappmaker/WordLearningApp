using WordLearning.CoreLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLearning.Domain.Shape
{
    public class WlShape
    : Enumeration
    {
        public static WlShape Star = new(Resource.Drawable.star, nameof(Star));
        public static WlShape Heart = new(Resource.Drawable.heart, nameof(Heart));
        public static WlShape Square = new(Resource.Drawable.square, nameof(Square));

        private static readonly IReadOnlyDictionary<int, WlShape> _shapeDictionary
            = GetAll<WlShape>().ToDictionary(shape => shape.Id, shape => shape);

        private WlShape(int id, string name)
            : base(id, name)
        {
        }


        public static WlShape Parse(int id)
        {
            if (!_shapeDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            return _shapeDictionary[id];
        }


        public static WlShape Parse(string id)
        {
            if (!int.TryParse(id, out int value))
            {
                throw new ArgumentException();
            }

            return Parse(value);
        }
    }
}
