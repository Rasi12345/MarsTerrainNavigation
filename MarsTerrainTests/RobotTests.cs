using MarsTerrainNavigation.Models;
using static MarsTerrainNavigation.Constants.Enums;

namespace MarsTerrainTests
{
    public class RobotTests
    {
        [Fact]
        public void Robot_Move_Fwd()
        {
            var grid = new Grid(5, 5);
            var command = "F";
            var robot = new Robot(1, 1, Directions.North, grid, command);
            robot.ExecuteCommands();

            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);
            Assert.Equal(Directions.North, robot.Direction);
        }

        [Fact]
        public void Robot_Turn_Left()
        {
            var grid = new Grid(5, 5);
            var command = "L";
            var robot = new Robot(1, 1, Directions.North, grid, command);
            robot.ExecuteCommands();

            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Directions.West, robot.Direction);
        }

        [Fact]
        public void Robot_Turn_Right()
        {
            var grid = new Grid(5, 5);
            var command = "R";
            var robot = new Robot(1, 1, Directions.North, grid, command);
            robot.ExecuteCommands();

            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Directions.East, robot.Direction);
        }

        [Theory]
        [InlineData(Directions.North, Directions.West)]
        [InlineData(Directions.West, Directions.South)]
        [InlineData(Directions.South, Directions.East)]
        [InlineData(Directions.East, Directions.North)]
        public void TurnLeft_Should_Change_Direction_Left(Directions initialDirection, Directions expectedDirection)
        {
            var grid = new Grid(5, 5);
            var command = "";
            var robot = new Robot(1, 1, initialDirection, grid, command);
            robot.TurnLeft();
            Assert.Equal(expectedDirection, robot.Direction);
        }

        [Theory]
        [InlineData(Directions.North, Directions.East)]
        [InlineData(Directions.West, Directions.North)]
        [InlineData(Directions.South, Directions.West)]
        [InlineData(Directions.East, Directions.South)]
        public void TurnLeft_Should_Change_Direction_Right(Directions initialDirection, Directions expectedDirection)
        {
            var grid = new Grid(5, 5);
            var command = "";
            var robot = new Robot(1, 1, initialDirection, grid, command);
            robot.TurnRight();
            Assert.Equal(expectedDirection, robot.Direction);
        }

        [Fact]

        public void Validate_Grid_Limit()
        {
            var grid = new Grid(5, 5);
            var command = "FFFFFFFFFFFF";
            var robot = new Robot(1, 1, Directions.North, grid, command);
            robot.ExecuteCommands();

            Assert.Equal(1, robot.X);
            Assert.Equal(5, robot.Y);
            Assert.Equal(Directions.North, robot.Direction);
        }

        [Fact]
        public void Validate_MinGrid_Limit()
        {
            var grid = new Grid(5, 5);
            var command = "FLFFLFFFF";
            var robot = new Robot(1, 1, Directions.North, grid, command);
            robot.ExecuteCommands();

            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Directions.South, robot.Direction);
        }

        [Fact]
        public void Validate_MaxGrid_Limit()
        {
            var grid = new Grid(5, 5);
            var command = "FFFFRFFFFLFFRFF";
            var robot = new Robot(1, 1, Directions.North, grid, command);
            robot.ExecuteCommands();

            Assert.Equal(5, robot.X);
            Assert.Equal(5, robot.Y);
            Assert.Equal(Directions.East, robot.Direction);
        }
    }
}