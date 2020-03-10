using MarsRoverCS.Business;
using MarsRoverCS.Entities.Concrete;
using System;

namespace MarsRoverCS.App
{
    class Program
    {
        static void Main(string[] args)
        {

            bool validPlateauInfo = false;
            while (!validPlateauInfo)
            {
                Console.WriteLine("Lütfen platonun X ve Y koordinatlarını girin:");
                var plateauInfo = Console.ReadLine();
                validPlateauInfo = PlateauService.SetCoordinate(plateauInfo);
            }

            while (true)
            {
                bool validRoverPosition = false;
                Rover rover = new Rover();
                while(!validRoverPosition)
                {
                    Console.WriteLine("Lütfen gezginin konumunu girin:");
                    var roverPostionInfo = Console.ReadLine();
                    validRoverPosition = rover.SetPosition(roverPostionInfo);
                }

                Console.WriteLine("Lütfen gezgin için komut girin:");
                var command = Console.ReadLine();

                rover.RunCommand(command);

                Console.WriteLine();
                var getPostion = rover.GetPostion();
                Console.WriteLine("Gezginin mevcut konumu:");
                Console.WriteLine(getPostion);
                Console.WriteLine();

            }
        }
    }
}
