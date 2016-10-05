using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Liskov.Sample2
{
    #region Nested type: Rectangle

    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int Area()
        {
            return Height * Width;
        }
    }

    #endregion

    #region Nested type: Shape

    public abstract class Shape
    {
    }

    #endregion



    public class Square : Shape
    {
        public int SideLength;

        public int Area()
        {
            return SideLength * SideLength;
        }
    }

}
