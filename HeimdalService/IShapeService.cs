using Heimdal.Domain;

namespace HeimdalService;

/// <summary>
/// Interface <see cref="ShapeService"/> containing Shape services
/// </summary>
public interface IShapeService
{
    /// <summary>
    /// Gets Shapes with random Circle and Rectangles.
    /// </summary>
    /// <param name="n">nymber of shapes</param>
    /// <returns>List of Shapes</returns>
    List<Shape> GetShapes(int n);

    /// <summary>
    /// Get the sum of perimeters of all the circles in the collection.
    /// </summary>
    /// <param name="shapes">Collection of shapes </param>
    /// <returns>double</returns>
    Task<double> GetSumOfCirclesAsync(List<Shape> shapes);
}