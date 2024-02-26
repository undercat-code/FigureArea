namespace FigureArea.Figures;

public abstract class Figure(double area)
{
    private readonly double _area = area;
    public double GetArea() { return _area; }
}