namespace Heimdal.Domain;


/// <summary>
/// Class <see cref="Shape"/>
/// </summary>
public class Shape
{
    /// <summary>
    /// Area
    /// </summary>
    public double Area { get; set; }

    /// <summary>
    /// Perimeter
    /// </summary>
    public double Perimeter { get; set; }

    /// <summary>
    /// Location
    /// </summary>
    public Location Location { get; set; }

    /// <summary>
    /// Constructor of Shape.
    /// </summary>
    public Shape()
    {
        Location = new();
    }
}