using MarsRoverCS.Business.Helper;
using MarsRoverCS.Entities.Concrete;
using MarsRoverCS.Entities.Enums;
using System;
using System.Linq;

namespace MarsRoverCS.Business
{
    public static class RoverService
    {
        readonly static char[] ValidCommand = { 'L', 'R', 'M' };
        public static string GetPostion(this Rover rover)
        {
            return rover.Position.XCoordinate + " " + rover.Position.YCoordinate + " " + (char)rover.Direction;
        }

        public static void Move(this Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.North:
                    rover.Position.YCoordinate = rover.Position.YCoordinate + 1;
                    break;
                case Direction.East:
                    rover.Position.XCoordinate = rover.Position.XCoordinate + 1;
                    break;
                case Direction.South:
                    rover.Position.YCoordinate = rover.Position.YCoordinate - 1;
                    break;
                case Direction.West:
                    rover.Position.XCoordinate = rover.Position.XCoordinate - 1;
                    break;
                default:
                    break;
            }
        }

        public static void RunCommand(this Rover rover, string command)
        {
            var commandArray = command.ToCharArray();
            var stopCommand = false;
            foreach (var item in commandArray)
            {
                if (ValidCommand.Contains(item))
                {

                    switch (item)
                    {
                        case 'L':
                            Turn(rover, Side.Left);
                            break;
                        case 'R':
                            Turn(rover, Side.Right);
                            break;
                        case 'M':
                            if (rover.CanItMove())
                            {
                                Move(rover);
                            }
                            else
                            {
                                stopCommand = true;
                                Console.WriteLine("Gezgin mevcut yönde ({0}) daha fazla ilerleyemez",rover.Direction.ToString());
                            }
                            break;
                    }
                    if (stopCommand)
                        break;
                }
                else
                {
                    Console.WriteLine("Geçersiz komut: " + item);
                    break;
                }
            }
        }

        public static void Turn(this Rover rover, Side side)
        {
            switch (rover.Direction)
            {
                case Direction.East:
                    rover.Direction = (side == Side.Left) ? Direction.North : Direction.South;
                    break;
                case Direction.West:
                    rover.Direction = (side == Side.Left) ? Direction.South : Direction.North;
                    break;
                case Direction.North:
                    rover.Direction = (side == Side.Left) ? Direction.West : Direction.East;
                    break;
                case Direction.South:
                    rover.Direction = (side == Side.Left) ? Direction.East : Direction.West;
                    break;
            }
        }

        public static bool SetPosition(this Rover rover, string positionInfo)
        {
            var positionArr = positionInfo.Split(' ');
            if (positionArr.Length == 3 && IsValidPosition(positionArr[0], positionArr[1], Plateau.Position) && IsValidDirection(positionArr[2]))
            {
                var x = int.Parse(positionArr[0]);
                var y = int.Parse(positionArr[1]);
                if (rover.Position == null)
                {
                    rover.Position = new Position(x, y);
                }
                else
                {
                    rover.Position.XCoordinate = x;
                    rover.Position.YCoordinate = y;
                }
                rover.Direction = (Direction)(Convert.ToChar(positionArr[2]));
                return true;
            }
            else
            {
                Console.WriteLine("|---Geçersiz veri girişi---|" + Environment.NewLine);
                return false;
            }
        }
        private static bool IsValidPosition(string X, string Y, Position plateauPosition)
        {
            // gezgin için girilen X ve Y koordinatlarının girilen plato değerleri için geçerli olmalı
            if ((int.TryParse(X, out int rx) && rx >= 0 && rx <= plateauPosition.XCoordinate)
                && int.TryParse(Y, out int ry) && ry >= 0 && ry <= plateauPosition.YCoordinate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool IsValidDirection(string direction)
        {
            // gezgin için girilen yönün geçerlilik kontrolü
            Direction val = ((Direction[])Enum.GetValues(typeof(Direction)))[0];
            if (char.TryParse(direction, out char d) && Utility.GetEnumValue<Direction>(d))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CanItMove(this Rover rover)
        {
            var position = rover.Position;           
            switch (rover.Direction)
            {
                case Direction.North:
                    return position.YCoordinate >= Plateau.YOrigin && position.YCoordinate < Plateau.Position.YCoordinate;
                case Direction.East:
                    return position.XCoordinate >= Plateau.XOrigin && position.XCoordinate < Plateau.Position.XCoordinate;
                case Direction.South:
                    return position.XCoordinate >= Plateau.XOrigin && position.YCoordinate > Plateau.YOrigin;
                case Direction.West:
                    return position.YCoordinate >= Plateau.YOrigin && position.XCoordinate > Plateau.XOrigin;
                default:
                    return false;
            }
   
        }

    }
}
