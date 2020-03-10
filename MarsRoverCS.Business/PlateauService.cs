using MarsRoverCS.Entities.Concrete;
using System;

namespace MarsRoverCS.Business
{
    public static class PlateauService
    {
        public static bool SetCoordinate(string coordinates)
        {
            var coordinateArr = coordinates.Split(' ');
            if (coordinateArr.Length == 2 && IsValidCoordinate(coordinateArr[0]) && IsValidCoordinate(coordinateArr[1]))
            {
                var x = int.Parse(coordinateArr[0]);
                var y = int.Parse(coordinateArr[1]);
                if (Plateau.Position == null)
                {
                    Plateau.Position = new Position(x, y);
                }
                else
                {
                    Plateau.Position.XCoordinate = x;
                    Plateau.Position.YCoordinate = y;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Geçersiz veri girişi yaptınız" + Environment.NewLine);
                return false;
            }

        }

       
        private static bool IsValidCoordinate(string param)
        {
            if (int.TryParse(param, out int t) && t > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
