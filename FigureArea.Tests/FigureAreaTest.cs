using System.Reflection;
using FigureArea.Figures;
using Xunit;

namespace FigureArea.Tests;

public class FigureAreaTest
{
    [Fact]
    public void PositiveRadiusCircleTest()
    {
        var act = Calculation.Calculation.Calculate(typeof(Circle), 7);
        Assert.Equal(153.93804002589985, act);
    }

    [Theory]
    [InlineData(0.0)]
    [InlineData(-7.0)]
    public void NegativeRadiusCircleTest(double circleRadius)
    {
        var result = Assert.Throws<TargetInvocationException>(() =>
            Calculation.Calculation.Calculate(typeof(Circle), circleRadius));
        Assert.IsType<ArgumentException>(result.InnerException);
        Assert.Equal("Radius can't be less or equal 0.0", result.InnerException.Message);
    }
    
    [Fact]
    public void PositiveSidesTriangleTest()
    {
        var act = Calculation.Calculation.Calculate(typeof(Triangle), 5.0, 10.5, 13.3);
        Assert.Equal(24.097601540402312, act);
    }
    
    [Theory]
    [InlineData(0.0, 2.0, 5.0)]
    [InlineData(10.0, 12.0, -14.0)]
    public void NegativeSidesTriangleTest(double side1, double side2, double side3)
    {
        var result = Assert.Throws<TargetInvocationException>(() =>
            Calculation.Calculation.Calculate(typeof(Triangle), side1, side2, side3));
        Assert.IsType<ArgumentException>(result.InnerException);
        Assert.Equal("Triangle sides can't be less or equal 0.0", result.InnerException.Message);
    }
    
    [Fact]
    public void IsTriangleRightTest()
    {
        Triangle triangle = new(5, 3, 4);
        Assert.True(triangle.IsTriangleRight);
    }
    
    [Fact]
    public void IncorrectParametersCircleTest()
    {
        var result = Assert.Throws<Exception>(() =>
            Calculation.Calculation.Calculate(typeof(Circle), 0.7, 0.1));
        Assert.Equal("Can't find right Constructor", result.Message);
    }
    
    [Fact]
    public void IncorrectParametersTriangleTest()
    {
        var result = Assert.Throws<Exception>(() =>
            Calculation.Calculation.Calculate(typeof(Triangle), 0.7, 0.1, 9.0, 13.0));
        Assert.Equal("Can't find right Constructor", result.Message);
    }
}