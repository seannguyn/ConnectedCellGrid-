using NUnit.Framework;
using ConnectedCellGrid;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Tests
{
    public class FunctionalTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Neighbor_TestCorner()
        {
            List<KeyValuePair<int, int>> correctNeighbor = new List<KeyValuePair<int, int>>();
            correctNeighbor.Add(new KeyValuePair<int, int>(0, 1));
            correctNeighbor.Add(new KeyValuePair<int, int>(1, 1));
            correctNeighbor.Add(new KeyValuePair<int, int>(1, 0));

            List<KeyValuePair<int,int>> neighbors = Solution.getNeighbor(0, 0, 3, 3);

            foreach(KeyValuePair<int, int> pair in correctNeighbor)
            {
                try
                {
                    var position = neighbors.First(x => x.Key == pair.Key && x.Value == pair.Value);
                }
                catch (Exception)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

        [Test]
        public void Neighbor_TestRow()
        {
            List<KeyValuePair<int, int>> correctNeighbor = new List<KeyValuePair<int, int>>();
            correctNeighbor.Add(new KeyValuePair<int, int>(0, 0));
            correctNeighbor.Add(new KeyValuePair<int, int>(1, 0));
            correctNeighbor.Add(new KeyValuePair<int, int>(1, 1));
            correctNeighbor.Add(new KeyValuePair<int, int>(1, 2));
            correctNeighbor.Add(new KeyValuePair<int, int>(0, 2));

            List<KeyValuePair<int, int>> neighbors = Solution.getNeighbor(0, 1, 3, 3);

            foreach (KeyValuePair<int, int> pair in correctNeighbor)
            {
                try
                {
                    var position = neighbors.First(x => x.Key == pair.Key && x.Value == pair.Value);
                }
                catch (Exception)
                {
                    Assert.Fail();
                }

            }
            Assert.Pass();
        }

        [Test]
        public void Neighbor_TestMiddle()
        {
            List<KeyValuePair<int, int>> correctNeighbor = new List<KeyValuePair<int, int>>();
            correctNeighbor.Add(new KeyValuePair<int, int>(0, 0));
            correctNeighbor.Add(new KeyValuePair<int, int>(0, 1));
            correctNeighbor.Add(new KeyValuePair<int, int>(0, 2));

            correctNeighbor.Add(new KeyValuePair<int, int>(1, 0));
            correctNeighbor.Add(new KeyValuePair<int, int>(1, 2));

            correctNeighbor.Add(new KeyValuePair<int, int>(2, 0));
            correctNeighbor.Add(new KeyValuePair<int, int>(2, 1));
            correctNeighbor.Add(new KeyValuePair<int, int>(2, 2));

            List<KeyValuePair<int, int>> neighbors = Solution.getNeighbor(1, 1, 3, 3);

            foreach (KeyValuePair<int, int> pair in correctNeighbor)
            {
                try
                {
                    var position = neighbors.First(x => x.Key == pair.Key && x.Value == pair.Value);
                }
                catch (Exception)
                {
                    Assert.Fail();
                }

            }
            Assert.Pass();
        }

        [Test]
        public void isValid_Test()
        {
            // OutOfBound
            Assert.IsFalse(Solution.isValid(-1, -1,0,0,3,3));
            Assert.IsFalse(Solution.isValid(4, 2, 0, 0, 3, 3));

            // Same as current position
            Assert.IsFalse(Solution.isValid(0, 0, 0, 0, 3, 3));

            // valid neighbor
            Assert.IsTrue(Solution.isValid(1, 1, 0, 0, 3, 3));
        }

        [Test]
        public void ConnectedCellGrid_Test0()
        {
            int[][] board = Program.ReadBoard("board0.txt");
            int nodes = Solution.connectedCell(board, board.Length, board[0].Length);
            Assert.AreEqual(nodes, 5);
        }

        [Test]
        public void ConnectedCellGrid_Test1()
        {
            int[][] board = Program.ReadBoard("board1.txt");
            int nodes = Solution.connectedCell(board, board.Length, board[0].Length);
            Assert.AreEqual(nodes, 8);
        }
    }
}