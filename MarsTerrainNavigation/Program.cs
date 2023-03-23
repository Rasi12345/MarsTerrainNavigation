using MarsTerrainNavigation;
using System;

Navigation_Mars nav = new Navigation_Mars("5X5", "FFRFLFLF");
(int i, int j, string direction) = nav.Traverse();
Console.WriteLine($"{i},{j},{direction}");