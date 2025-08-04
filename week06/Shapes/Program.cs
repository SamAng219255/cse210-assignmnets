using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>{
            new Square("red", 3.0),
            new Rectangle("green", 5.0, 6.0),
            new Circle("blue", 2.0)
        };

        foreach(Shape shape in shapes) {
            Console.WriteLine($"Color: {shape.GetColor()}\nArea: {shape.GetArea()}\n");
        }
    }
}