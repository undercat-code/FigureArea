using FigureArea.Figures;

namespace FigureArea.Calculation;

public class Calculation
{
    public static double Calculate(Type figureType, params object[] args)
    {
        //Get figure type constructors 
        var constructors = figureType.GetConstructors();
        
        if (constructors.Length == 0)
        {
            throw new Exception("Can't find Constructor");
        }
        
        //Find right constructor
        var constructor = constructors.FirstOrDefault(x => x.IsPublic && x.GetParameters().Length == args.Length);
        
        if (constructor == null)
        {
            throw new Exception("Can't find right Constructor");
        }
        
        //Cast object type to Figure and Run constructor
        var figure = constructor.Invoke(args) as Figure;
        var result = figure.GetArea();
        return result;
    }
}