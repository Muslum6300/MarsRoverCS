using MarsRoverCS.Entities.Concrete;
using MarsRoverCS.Entities.Enums;

namespace MarsRoverCS.Entities.Abstraction
{
    public interface IRover
    {
        Position Position { get; set; }
        Direction Direction { get; set; }
    }
}
