using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsTerrainNavigation
{
    public class Navigation_Mars
    {
        public int X = 1;
        public int Y = 1;
        public int X_Max { get; set; }
        public int Y_Max { get; set; }
        public string InputCommand { get; set; }

        private string _direction = Directions_enum.North;
        public Navigation_Mars(string plateauSize, string inputCommand)
        {
            X_Max = plateauSize.ToCharArray().First();
            Y_Max = plateauSize.ToCharArray().Last();
            InputCommand = inputCommand;
        }

        public void SetDirection(char turn)
        {
            if (turn == 'F') return;
            if (_direction == Directions_enum.North)
            {
                if (turn == 'L') _direction = Directions_enum.West;
                else _direction = Directions_enum.East;
            }
            else if (_direction == Directions_enum.West)
            {
                if (turn == 'L') _direction = Directions_enum.South;
                else _direction = Directions_enum.North;

            }
            else if (_direction == Directions_enum.East)
            {
                if (turn == 'L') _direction = Directions_enum.North;
                else _direction = Directions_enum.South;

            }
            else
            {
                if (turn == 'L') _direction = Directions_enum.East;
                else _direction = Directions_enum.West;

            }
        }

        public void Move()
        {
            if (_direction == Directions_enum.North)
            {
                if (Y + 1 > Y_Max) return;
                else Y++;
            }
            else if (_direction == Directions_enum.East)
            {
                if (X + 1 > Y_Max) return;
                else X++;
            }
            else if (_direction == Directions_enum.South)
            {
                if (Y - 1 < 0) return;
                else Y--;
            }
            else if (_direction == Directions_enum.West)
            {
                if (X - 1 < 0) return;
                else X--;
            }
        }

        //5x5
        //FFRFLFLF

        public (int, int, string) Traverse()
        {
            foreach (var item in InputCommand)
            {
                if (item == 'F') Move();
                SetDirection(item);
            }
            return (X, Y, _direction);
        }
    }
}
