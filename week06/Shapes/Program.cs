using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Rectangle("Red", 5, 10));
        shapes.Add(new Rectangle("Blue", 7, 7));
        shapes.Add(new Circle("Green", 4));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():0.00}");
        }
    }
}
