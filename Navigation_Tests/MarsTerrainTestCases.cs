using MarsTerrainNavigation;
using Xunit;

namespace Navigation_Tests
{
    public class MarsTerrainTestCases
    {
        [Fact]
        public void Test1() 
        {
            Navigation_Mars nav = new Navigation_Mars("5X5", "FFRFLFLF");
            (int i, int j, string direction) = nav.Traverse();

            Assert.Equal(3, i);

            Assert.Equal(4, j);

            Assert.Equal("north", direction);
        }

        [Fact]
        public void Test2()
        {
            Navigation_Mars nav = new Navigation_Mars("5X5", "FFRFLFLF");
            (int i, int j, string direction) = nav.Traverse();
            Assert.Equal(1, i);

            Assert.Equal(4, j);

            Assert.Equal("west", direction);
        }
    }
}