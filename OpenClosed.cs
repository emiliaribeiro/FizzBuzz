using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 1. Cria uma classe Circle e estende a classe AreaCalcultor para calcular a área total de círculos e rectângulos
// 2. Se fosse para criar uma terceira forma e que precisasse de adicionar ao AreaCalculator, como farias?
namespace FizzBuzz
{
    /// <summary>
    /// Representa um rectangulo
    /// </summary>
    public class Rectangle : GenericShape
    {
        public Rectangle(double height, double perpendicularHeight)
        {
            this.Height = height;
            this.PerpendicularHeight = perpendicularHeight;
        }

        public override double ShapeArea()
        {
            return this.Height * this.PerpendicularHeight;
        }
    }

    /// <summary>
    /// Representa um círculo
    /// </summary>
    public class Circle: GenericShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        
        public override double ShapeArea()
        {
            return Math.Pow(this.Radius, 2) * Math.PI;
        }
    }

    /// <summary>
    /// For a new shape we just need to define a class witch implements GenericShape and define the method for calaculate the area and the constructor with the values needed for that specific shape
    /// </summary>
    public class NewShape : GenericShape
    {
        public NewShape()
        {

        }

        public override double ShapeArea()
        {
            double area = 0;
            //area formula for this shape
            return area;
        }
    }

    //Represents a generic class of a shape with all possible needed values (in case that some value is missing for a new shape just add the property
    public class GenericShape
    {
        public double Height { get; set; }
        public double Radius { get; set; }
        public double Base { get; set; }
        public double Lenght { get; set; }
        public double PerpendicularHeight { get; set; }

        // Virtual method which returns the area value for each shape
        public virtual double ShapeArea()
        {
            double area = 0;
            return area;
        }

        /// <summary>
        ///constructor if need for some reason, with default values in order to be possible to instantiate every shapes possibilities
        /// <summary>
        public GenericShape(double height = 0, double radius = 0, double baseValue = 0, double lenght = 0, double perpendicularHeight = 0)
        {
            this.Height = height;
            this.Radius = radius;
            this.Base = baseValue;
            this.Lenght = lenght;
            this.PerpendicularHeight = perpendicularHeight;
        }
    }

    /// <summary>
    /// Calculate area class
    /// </summary>
    public static class AreaCalculator
    {
        /// <summary>
        /// Calculate Rectangle area (existing method from test)
        /// </summary>
        public static double Area(Rectangle[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.ShapeArea();
            }
            return area;
        }

        /// <summary>
        /// Calculate CircleArea area (existing method from test)
        /// </summary>
        public static double CircleArea(Circle[] circles)
        {
            double area = 0;
            foreach (var circle in circles)
            {
                area += circle.ShapeArea();
            }
            return area;
        }

        /// <summary>
        /// Calculate CircleArea and rectangles area (with existing methods from test)
        /// </summary>
        public static double TotalAreaCirclesAndRectangles(Circle[] circles, Rectangle[] shapes)
        {
            double area = CircleArea(circles) + Area(shapes);

            return area;
        }

        /// <summary>
        /// Implementation of a generic method to calculate areas given a name = shapeType and a list of sizes
        /// </summary>
        public static double TotalAreaShapesList(Dictionary<string, List<GenericShape>> shapes)
        {
            double area = 0;

            foreach(var shape in shapes)
            {
                area += GetArea(shape);
            }

            return area;
        }

        /// <summary>
        /// returns the total area value for a given shape, in case of new shape just add the name and create new shape object overiding the method of ShapeArea
        /// </summary>
        private static double GetArea(KeyValuePair<string, List<GenericShape>> shape)
        {
            double area = 0;
            string shapeType = shape.Key;
            switch (shapeType)
            {
                case "Circle":
                    foreach (Circle circle in shape.Value)
                        area += circle.ShapeArea();
                    break;
                case "Rectangle":
                    foreach(Rectangle rectangle in shape.Value)
                    area += rectangle.ShapeArea();
                    break;
                case "NewShape":
                    foreach (NewShape newShape in shape.Value)
                        area += newShape.ShapeArea();
                    break;
                default:
                    break;
            }

            return area;
        }
    }
}
