namespace Task.Task1;

//Все классы специально расположены в одном файле, для удобства ревью

/// <summary>
/// Фигура
/// </summary>
public interface IShape
{
    /// <summary>
    /// Вычислить площадь
    /// </summary>
    double CalculateArea();
}

/// <summary>
/// Круг
/// </summary>
public class Circle : IShape
{
    private double Radius { get; }
    
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Радиус не может быть отрицательный");
            
        }
        
        Radius = radius;
    }

    /// <inheritdoc />
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

/// <summary>
/// Триугольник
/// </summary>
public class Triangle : IShape
{
    private double SideA { get; }
    private double SideB { get; }
    private double SideC { get; }
    
    /// <summary>
    /// ctor
    /// </summary>
    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Сторона не может быть 0 или отрицательной");
        }
        
        SideC = sideC;
        SideB = sideB;
        SideA = sideA;
    }

    /// <inheritdoc />
    public double CalculateArea()
    {
        if (TryCalculateAreaRightAngled(out var area))
        {
            return area;
        }
        
        var s = (SideA + SideB + SideC) / 2;
        var result = Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        return result;

    }

    /// <summary>
    /// Если треугольник прямоугольный то сразу вычисляем его площадь
    /// </summary>
    /// <remarks>
    /// Проверяем по теореме пифагора
    /// </remarks>
    private bool TryCalculateAreaRightAngled(out double area)
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        
        var result = Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1E-6;

        area = 0;
        
        if (result)
        {
            area = 0.5 * sides[0] * sides[1];
        }
        
        return result; 
    }
}
