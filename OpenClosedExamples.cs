using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
    class OpenClosedExamples
    {
        private List<GenericShape> circles = new List<GenericShape>();
        private List<GenericShape> rectangles = new List<GenericShape>();
        private List<GenericShape> newShapes = new List<GenericShape>();
        private Dictionary<string, List<GenericShape>> shapes = new Dictionary<string, List<GenericShape>> ();
        
        public OpenClosedExamples()
        {
            this.InitializeElements();
            this.CalculateTotalArea();
        }

        private void InitializeElements()
        {
            
            for (int i = 0; i < 10; i++)
            {
                Circle circle = new Circle(i);
                this.circles.Add(circle);
            }
            
            shapes.Add("Circle", this.circles);

            for (int i = 0; i < 10; i++)
            {
                Rectangle rectangle = new Rectangle(i, i*2);
                this.rectangles.Add(rectangle);
            }

            this.shapes.Add("Rectangle", this.rectangles);

            for (int i = 0; i < 10; i++)
            {
                NewShape newShape = new NewShape();
                this.newShapes.Add(newShape);
            }

            this.shapes.Add("NewShape", this.newShapes);
        }

        private void CalculateTotalArea()
        {
            double totalArea = AreaCalculator.TotalAreaShapesList(this.shapes);
        }
    }
}
