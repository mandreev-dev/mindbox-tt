using Xunit;

namespace Task.Task1;

/// Тесты для <inheritdoc cref="Circle"/>
public class CircleTests
{
    [Fact]
    public void CalculateArea_WithPositiveRadius_ReturnsCorrectArea()
    {
        var circle = new Circle(5);
        var expectedArea = Math.PI * 25;

        var area = circle.CalculateArea();

        Assert.Equal(expectedArea, area, 2);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void CalculateArea_WithZeroRadius_ReturnsZero(double radius)
    {
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }
}

/// Тесты для <inheritdoc cref="Triangle"/>
public class TriangleTests
{
    [Fact]
    public void CreateTriangle_WithPositiveSides_ShouldSucceed()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.NotNull(triangle);
    }

    [Theory]
    [InlineData(0, 1, 1)]
    [InlineData(-1, 1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, -1, 1)]
    [InlineData(1, 1, 0)]
    [InlineData(1, 1, -1)]
    public void CreateTriangle_WithNonPositiveSide_ShouldThrowArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Fact]
    public void CalculateArea_WithNonRightAngledTriangle_ShouldReturnCorrectArea()
    {
        var triangle = new Triangle(3, 4, 6);
        var expectedArea = Math.Sqrt((3 + 4 + 6) / 2 * ((3 + 4 + 6) / 2 - 3) * ((3 + 4 + 6) / 2 - 4) * ((3 + 4 + 6) / 2 - 6));
        Assert.Equal(expectedArea, triangle.CalculateArea(), 5);
    }

    [Fact]
    public void CalculateArea_WithRightAngledTriangle_ShouldReturnCorrectArea()
    {
        var triangle = new Triangle(3, 4, 5); // 3 and 4 are legs, 5 is the hypotenuse
        var expectedArea = 0.5 * 3 * 4;
        Assert.Equal(expectedArea, triangle.CalculateArea(), 5);
    }
}

