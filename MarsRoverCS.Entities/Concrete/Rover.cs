using MarsRoverCS.Entities.Abstraction;
using MarsRoverCS.Entities.Enums;

namespace MarsRoverCS.Entities.Concrete
{
    public class Rover : IRover
    {
        public Rover()
        {

        }
        public Rover(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
    }
}
