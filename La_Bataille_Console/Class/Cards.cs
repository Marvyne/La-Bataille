using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace La_Bataille_Console.Class
{

    public class Cards
    {
        public enumColor _Color { get; set; }
        public enumValue _Value { get; set; }

        public enum enumColor { Coeur, Pîque, Carreau, Trèfle}
        public enum enumValue { deux, trois, quatre, cinq, six, sept, huit, neuf, dix, valet, dame, roi, As}

        public Cards(enumColor color, enumValue value)
        {
            _Color = color;
            _Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Cards cards &&
                   _Color == cards._Color &&
                   _Value == cards._Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_Color, _Value);
        }
    }
}
