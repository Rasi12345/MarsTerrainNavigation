using MarsTerrainNavigation.Classes;
using MarsTerrainNavigation.Models;
using static MarsTerrainNavigation.Constants.Enums;

var grid = new Grid(5, 5);
var command = "FFRFLFLF";

var robot = new Robot(1, 1, Directions.North, grid, command);

robot.ExecuteCommands();

Console.WriteLine($"{robot.X},{robot.Y},{Enum.GetName(robot.Direction)}");