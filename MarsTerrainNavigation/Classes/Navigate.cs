using MarsTerrainNavigation.Interfaces;
using MarsTerrainNavigation.Models;

namespace MarsTerrainNavigation.Classes
{
    internal class MoveForwardCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.Move();
        }
    }

    internal class TurnLeftCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.TurnLeft();
        }
    }

    internal class TurnRightCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.TurnRight();
        }
    }
}
