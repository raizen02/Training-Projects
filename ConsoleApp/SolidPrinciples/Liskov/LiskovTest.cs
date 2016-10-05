using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Liskov
{
    [TestClass]
    class LiskovTest
    {
        [TestMethod]
        public void GetArea()
        {
            Rectangle newRectangle = new Square();
            newRectangle.Width = 4;
            newRectangle.Height = 5;
            Assert.AreEqual(20, AreaCalculator.CalculateArea(newRectangle));
        }


        [TestMethod]
        public void GetTotalArea()
        {
            var shapes = new List<SolidPrinciples.Liskov.Sample2.Shape>
                             {
                                 new SolidPrinciples.Liskov.Sample2.Rectangle {Height = 4, Width = 5},
                                 new SolidPrinciples.Liskov.Sample2.Square {SideLength = 3}
                             };
            var areas = new List<int>();
            foreach (SolidPrinciples.Liskov.Sample2.Shape shape in shapes)
            {
                if (shape.GetType() == typeof(SolidPrinciples.Liskov.Sample2.Rectangle))
                {
                    areas.Add(((SolidPrinciples.Liskov.Sample2.Rectangle)shape).Area());
                }
                if (shape.GetType() == typeof(Square))
                {
                    areas.Add(((SolidPrinciples.Liskov.Sample2.Square)shape).Area());
                }
            }
            Assert.AreEqual(20, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }



        [TestMethod]
        public void GetTotalArea2()
        {
            var shapes = new List<SolidPrinciples.Liskov.Sample3.Shape>
                             {
                                 new SolidPrinciples.Liskov.Sample3.Rectangle {Height = 4, Width = 5},
                                 new SolidPrinciples.Liskov.Sample3.Square {SideLength = 3}
                             };
            var areas = new List<int>();
            foreach (SolidPrinciples.Liskov.Sample3.Shape shape in shapes)
            {
                areas.Add(shape.Area());
            }
            Assert.AreEqual(20, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }

    }
}
