using Heimdal.Domain;
using HeimdalService;
using Microsoft.Extensions.DependencyInjection;

var builder = new ServiceCollection()
    .AddScoped<IShapeService, ShapeService>()
    .BuildServiceProvider();

IShapeService shapeService = builder.GetService<IShapeService>();

Console.WriteLine("Give positive number:");

bool isNumeric = int.TryParse(Console.ReadLine(), out int n);
if (!isNumeric || n < 0)
{
    Console.WriteLine($"the input must be a positive number");
    Console.ReadLine();
    return;
}

List<Shape> shapes = shapeService.GetShapes(n);

foreach (Shape shape in shapes)
{
    if (shape is Rectangle)
    {
        Console.WriteLine($"Rectangle, Perimeter is {shape.Perimeter}");
    }
    else
    {
        Console.WriteLine($"Circle, Perimeter is {shape.Perimeter}");
    }
}

// GetSumOfCircles
double perimetersCircles = await shapeService.GetSumOfCirclesAsync(shapes);

Console.WriteLine();
Console.WriteLine($"The sum of circles perimeters: {perimetersCircles}");

Console.ReadLine();