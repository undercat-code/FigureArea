namespace FigureArea.Figures;

public class Circle : Figure
{
    private readonly double _circleRadius;

    public Circle(double circleRadius) : base(Math.PI * circleRadius * circleRadius)
    {
        _circleRadius = circleRadius;
        if (circleRadius <= 0.0) throw new ArgumentException("Radius can't be less or equal 0.0");
    }
}