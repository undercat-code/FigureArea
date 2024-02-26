namespace FigureArea.Figures;

public class Triangle : Figure
{
    private readonly double[] _triangleSides;
    public bool IsTriangleRight => Math.Pow(_triangleSides[2], 2) == (Math.Pow(_triangleSides[1], 2) + Math.Pow(_triangleSides[0], 2));
    public Triangle(double side1, double side2, double side3) : base(
        Math.Sqrt(
            ((side1+side2+side3) / 2) * 
            (((side1+side2+side3) / 2) - side1) * 
            (((side1+side2+side3) / 2) - side2) * 
            (((side1+side2+side3) / 2) - side3)
                    ))
    {
        if (side1 <= 0 || side2 <= 0 || side3 <= 0) throw new ArgumentException("Triangle sides can't be less or equal 0.0");
        _triangleSides = new[] { side1, side2, side3 };
        Array.Sort(_triangleSides);
    }
}