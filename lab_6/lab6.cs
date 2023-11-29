using System;

public interface IDisplayable
{
    void Display();
}

public interface IAreaCalculatable
{
    double CalculateArea();
}

public abstract class Shape : IDisplayable, IAreaCalculatable
{
    public double X { get; protected set; }
    public double Y { get; protected set; }

    protected Shape(double x, double y)
    {
        X = x;
        Y = y;
    }

    public abstract void Display();
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; private set; }

    public Circle(double x, double y, double radius) : base(x, y)
    {
        Radius = radius;
    }

    public override void Display()
    {
        Console.WriteLine($"Circle: Center ({X}, {Y}), Radius {Radius}");
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Cone : Shape
{
    public double Radius { get; private set; }
    public double Height { get; private set; }

    public Cone(double x, double y, double radius, double height) : base(x, y)
    {
        Radius = radius;
        Height = height;
    }

    public override void Display()
    {
        Console.WriteLine($"Cone: Base Center ({X}, {Y}), Radius {Radius}, Height {Height}");
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius + Math.PI * Radius * Math.Sqrt((Height * Height) + (Radius * Radius));
    }
}

class Program
{
    static void Main()
    {
        IDisplayable displayableShape;
        IAreaCalculatable calculatableShape;

        Console.WriteLine("Choose an object to create:");
        Console.WriteLine("1. Circle");
        Console.WriteLine("2. Cone");
        Console.Write("Enter your choice (1 or 2): ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                displayableShape = new Circle(0, 0, 5);
                calculatableShape = (IAreaCalculatable)displayableShape;
                break;
            case 2:
                displayableShape = new Cone(0, 0, 5, 10);
                calculatableShape = (IAreaCalculatable)displayableShape;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        displayableShape.Display();
        Console.WriteLine($"Area: {calculatableShape.CalculateArea()}");
    }
}
