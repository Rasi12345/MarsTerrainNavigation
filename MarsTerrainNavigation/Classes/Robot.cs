using MarsTerrainNavigation.Classes;
using MarsTerrainNavigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsTerrainNavigation.Constants.Enums;

namespace MarsTerrainNavigation.Models
{
    public class Robot
    {
        private readonly Grid _grid;
        private readonly IList<ICommand> _commands;
        public int X { get; private set; }
        public int Y { get; private set; }
        public Directions Direction { get; private set; }

        public Robot(int x, int y, Directions direction, Grid grid, string commands)
        {
            X = x;
            Y = y;
            Direction = direction;
            _grid = grid;
            _commands = ExtractCommand(commands);
        }

        private IList<ICommand> ExtractCommand(string commands)
        {
            List<ICommand> executableCommands = new List<ICommand>();

            foreach (char command in commands)
            {
                if (command == 'F') executableCommands.Add(new MoveForwardCommand());
                else if (command == 'L') executableCommands.Add(new TurnLeftCommand());
                else if (command == 'R') executableCommands.Add(new TurnRightCommand());
                else throw new InvalidOperationException("Invalid command");
            }
            return executableCommands;
        }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute(this);
            }
        }

        public void Move()
        {
            var newX = X;
            var newY = Y;

            switch (Direction)
            {
                case Directions.North:
                    newY++;
                    break;
                case Directions.East:
                    newX++;
                    break;
                case Directions.South:
                    newY--;
                    break;
                case Directions.West:
                    newX--;
                    break;
            }

            if (_grid.IsValidPosition(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }
        
        public void TurnLeft()
        {
            Direction = Direction switch
            {
                Directions.North => Directions.West,
                Directions.West => Directions.South,
                Directions.South => Directions.East,
                Directions.East => Directions.North,
                _ => throw new InvalidOperationException("Invalid direction"),
            };
        }

        public void TurnRight()
        {
            Direction = Direction switch
            {
                Directions.North => Directions.East,
                Directions.East => Directions.South,
                Directions.South => Directions.West,
                Directions.West => Directions.North,
                _ => throw new InvalidOperationException("Invalid direction"),
            };
        }
    }
}
