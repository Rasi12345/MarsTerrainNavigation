using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsTerrainNavigation.Models
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public bool IsValidPosition(int x, int y)
        {
            return x > 0 && x <= _width && y > 0 && y <= _height;
        }

    }
}
