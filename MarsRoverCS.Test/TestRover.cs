using MarsRoverCS.Business;
using MarsRoverCS.Entities.Concrete;
using MarsRoverCS.Entities.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverCS.Test
{
    [TestClass]
    public class TestRover
    {
        [TestMethod]
        public void CheckRover()
        {
            PlateauService.SetCoordinate("5 5");
            Rover rover = new Rover(new Position(1, 2), Direction.North);
            rover.RunCommand("LMLMLMLMM");
            var output = rover.GetPostion();
            Assert.AreEqual(output, "1 3 N");
        }
    }
}
