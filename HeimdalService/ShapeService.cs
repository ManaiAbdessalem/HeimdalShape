using Heimdal.Domain;

namespace HeimdalService;

/// <summary>
/// Class <see cref="ShapeService"/> containing Shape services
/// </summary>
public class ShapeService : IShapeService
{
    /// <inheritdoc />
    public async Task<double> GetSumOfCirclesAsync(List<Shape> shapes)
    {
        int shapeCount = shapes.Count();
        List<Shape> shapes1 = shapes.GetRange(0, shapeCount / 2);
        List<Shape> shapes2 = shapes.GetRange(shapes.Count() / 2, shapeCount - (shapeCount / 2));

        double sumPerimeter1 = 0;
        double sumPerimeter2 = 0;

        var tasks = new List<Task>();

        tasks.Add(Task.Run(() => SumOfCircles(shapes1, ref sumPerimeter1)));
        tasks.Add(Task.Run(() => SumOfCircles(shapes2, ref sumPerimeter2)));
        await Task.WhenAll(tasks.AsParallel());

        return sumPerimeter1 + sumPerimeter2;
    }

    /// <inheritdoc />
    public List<Shape> GetShapes(int n)
    {
        List<Shape> shapes = new();
        Array values = Enum.GetValues(typeof(ShapeEnum));
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            ShapeEnum randomShape = (ShapeEnum)values.GetValue(random.Next(values.Length));
            if (randomShape is ShapeEnum.Circle)
            {
                shapes.Add(new Rectangle() { Perimeter = i, Side1 = 1, Side2 = 2 });
            }
            else
            {
                shapes.Add(new Circle() { Perimeter = i, Radius = 123 });
            }
        }

        return shapes;
    }

    private void SumOfCircles(List<Shape> shapes, ref double sumPerimeter)
    {
        foreach (Shape shape in shapes)
        {
            if (shape is Circle)
            {
                sumPerimeter += shape.Perimeter;
            }
        }
    }
}