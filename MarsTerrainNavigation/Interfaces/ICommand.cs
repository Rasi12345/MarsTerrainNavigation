using MarsTerrainNavigation.Models;

namespace MarsTerrainNavigation.Interfaces
{
    public interface ICommand
    {
        void Execute(Robot robot);
    }
}
