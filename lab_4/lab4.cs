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

    public double CalculateCircumference()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Cone : Circle
{
    public double VertexX { get; set; }
    public double VertexY { get; set; }
    public double SlantHeight { get; set; }

    public Cone(double x, double y, double radius, double vertexX, double vertexY, double slantHeight)
        : base(x, y, radius)
    {
        VertexX = vertexX;
        VertexY = vertexY;
        SlantHeight = slantHeight;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Cone: Vertex ({VertexX}, {VertexY}), Slant Height {SlantHeight}");
    }

    public double CalculateLateralSurfaceArea()
    {
        return Math.PI * Radius * SlantHeight;
    }

    // Визначення радіуса основи конуса (вже є у базовому класі)
    public double CalculateBaseRadius()
    {
        return Radius;
    }
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle(0, 0, 5);
        circle.Display();
        Console.WriteLine($"Circumference of the circle: {circle.CalculateCircumference()}");

        Cone cone = new Cone(0, 0, 5, 0, 10, 8);
        cone.Display();
        Console.WriteLine($"Lateral surface area of the cone: {cone.CalculateLateralSurfaceArea()}");
        Console.WriteLine($"Base radius of the cone: {cone.CalculateBaseRadius()}");
    }
}
