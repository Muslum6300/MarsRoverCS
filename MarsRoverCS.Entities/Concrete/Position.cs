using MarsRoverCS.Entities.Abstraction;

namespace MarsRoverCS.Entities.Concrete
{
    public class Position : IPosition
    {
        public Position()
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }
        public Position(int x,int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

     
      
    }
}
