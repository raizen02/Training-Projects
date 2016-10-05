using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Liskov.Sample3
{

    public abstract class Shape
    {
        public abstract int Area();
        public
    }

    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override int Area()
        {
            return Height * Width;
        }
    }
    public class Square : Shape
    {
        public int SideLength;

        public override int Area()
        {
            return SideLength * SideLength;
        }
    }
}

