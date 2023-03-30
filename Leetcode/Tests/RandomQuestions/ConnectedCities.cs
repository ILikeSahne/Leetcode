using FluentAssertions;

namespace Leetcode.Tests.RandomQuestions
{
    public class ConnectedCitiesSolution
    {
        public int FindCircleNum(int[][] isConnected)
        {
            var unique = new (bool first, bool alreadyConnected)[isConnected.Length];
            for (var i = 0; i < unique.Length; i++)
            {
                unique[i] = (false, false);
            }

            for (var i = 0; i < isConnected.Length; i++)
            {
                CheckConnections(unique, isConnected, i, true);
            }

            return unique.Count(u => u.first);
        }

        private void CheckConnections((bool first, bool alreadyConnected)[] unique, int[][] isConnected, int i, bool first)
        {
            var connections = isConnected[i];

            if (unique[i].alreadyConnected)
            {
                return;
            }

            unique[i].first = first;
            unique[i].alreadyConnected = true;

            for (var j = 0; j < connections.Length; j++)
            {
                if (connections[j] == 1)
                {
                    CheckConnections(unique, isConnected, j, false);
                }
            }
        }
    }

    public class ConnectedCitiesTests
    {
        private readonly ConnectedCitiesSolution _connectedCities;

        public ConnectedCitiesTests()
        {
            _connectedCities = new ConnectedCitiesSolution();
        }

        [Fact]
        public void ConnectedCitiesShouldBe2()
        {
            var result = _connectedCities.FindCircleNum(new[]
            {
                new [] { 1, 1, 0 },
                new [] { 1, 1, 0 },
                new [] { 0, 0, 1 }
            });

            result.Should().Be(2);
        }

        [Fact]
        public void ConnectedCitiesShouldBe3()
        {
            var result = _connectedCities.FindCircleNum(new[]
            {
                new [] { 1, 0, 0 },
                new [] { 0, 1, 0 },
                new [] { 0, 0, 1 }
            });

            result.Should().Be(3);
        }

        [Fact]
        public void ConnectedCitiesShouldBe1()
        {
            var result = _connectedCities.FindCircleNum(new[]
            {
                new [] { 1, 1, 0 },
                new [] { 0, 1, 1 },
                new [] { 1, 0, 1 }
            });

            result.Should().Be(1);
        }
    }
}
