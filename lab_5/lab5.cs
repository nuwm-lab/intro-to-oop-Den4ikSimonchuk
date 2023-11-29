using System;

public class Circle
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Radius { get; set; }

    public Circle(double x, double y, double radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Circle: Center ({X}, {Y}), Radius {Radius}");
    }

    public virtual double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Cone : Circle
{
    public double Height { get; set; }

    public Cone(double x, double y, double radius, double height)
        : base(x, y, radius)
    {
        Height = height;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Cone: Height {Height}");
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * (Radius + Math.Sqrt(Height * Height + Radius * Radius));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose an object to create:");
        Console.WriteLine("1. Circle");
        Console.WriteLine("2. Cone");
        Console.Write("Enter your choice (1 or 2): ");
        int choice = int.Parse(Console.ReadLine());

        Circle shape;

        switch (choice)
        {
            case 1:
                shape = new Circle(0, 0, 5);
                break;
            case 2:
                shape = new Cone(0, 0, 5, 10);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        shape.Display();
        Console.WriteLine($"Area: {shape.CalculateArea()}");
    }
}
