using MarsRoverCS.Entities.Concrete;

namespace MarsRoverCS.Entities.Abstraction
{
    public interface IPlateau
    {
        int XOrigin { get; set; }
        int YOrigin { get; set; }
        Position Position { get; set; }
    }
}
