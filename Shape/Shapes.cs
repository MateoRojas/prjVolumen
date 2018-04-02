using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjVolumen.Shapes
{
    interface IShape
    {
        Double getArea();
    }

    class Square : IShape
    {
        public Double Side { get; set; }

        public Square(double side)
        {
            this.Side = side;
        }

        public Double getArea() => this.Side * this.Side;
    }

    class Rectangle : IShape
    {
        public Double Height { get; set; }
        public Double Width { get; set; }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public Double getArea() => this.Height * this.Width;
    }

    class Triangule : IShape
    {
        public Double Bottom { get; set; }
        public Double Heigth { get; set; }

        public Triangule(double bottom, double heigth)
        {
            Bottom = bottom;
            Heigth = heigth;
        }

        public Double getArea() => (this.Heigth * this.Bottom) / 2;
    }
}
