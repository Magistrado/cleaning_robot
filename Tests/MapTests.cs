using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CleaningRobot;

namespace Tests
{
    [TestFixture]
    class MapTests
    {
        OpMap map = null;
        Map[,] m = null;
        [SetUp] 
        public void init()
        {
            m =  new Map[,]
            {
                {Map.S, Map.S, Map.S, Map.S},
                {Map.S, Map.S, Map.C, Map.S},
                {Map.S, Map.S, Map.S, Map.S},
                {Map.S, Map.N, Map.S, Map.S},
            };
        }

        [Test]
        public void advance_facingNorth_returns0()
        {
            map = new OpMap(m, Direction.N, 1, 1);
            map.advance();
            Assert.AreEqual(map.YCoord, 0);
        }

        [Test]
        public void back_facingNorth_returns2()
        {
            map = new OpMap(m, Direction.N, 1, 1);
            map.back();
            Assert.AreEqual(map.YCoord, 2);
        }

        [Test]
        public void advance_facingWest_returns0()
        {
            map = new OpMap(m, Direction.W, 1, 1);
            map.advance();
            Assert.AreEqual(map.XCoord, 0);
        }

        [Test]
        public void back_facingWest_returns0()
        {
            map = new OpMap(m, Direction.W, 1, 1);
            map.back();
            Assert.AreEqual(map.XCoord, 2);
        }

        [Test]
        public void turnLeft_facingWest_returnsSouth()
        {
            map = new OpMap(m, Direction.W, 1, 1);
            map.turnLeft();
            Assert.AreEqual(map.Direction, Direction.S);
        }

        [Test]
        public void turnLeft_facingWestTurn360_returnsWest()
        {
            map = new OpMap(m, Direction.W, 1, 1);
            map.turnLeft();
            map.turnLeft();
            map.turnLeft();
            map.turnLeft();
            Assert.AreEqual(map.Direction, Direction.W);
        }

        [Test]
        public void turnLeft_facingWestTurn270_returnsWest()
        {
            map = new OpMap(m, Direction.W, 1, 1);
            map.turnLeft();
            map.turnLeft();
            map.turnLeft();
            Assert.AreEqual(map.Direction, Direction.N);
        }

        [Test]
        public void turnRight_facingWest_returnsSouth()
        {
            map = new OpMap(m, Direction.N, 1, 1);
            map.turnRight();
            Assert.AreEqual(map.Direction, Direction.E);
        }

        [Test]
        public void turnRight_facingNorthTurn360_returnsWest()
        {
            map = new OpMap(m, Direction.N, 1, 1);
            map.turnRight();
            map.turnRight();
            map.turnRight();
            map.turnRight();
            Assert.AreEqual(map.Direction, Direction.N);
        }

        [Test]
        public void turnRight_facingNorthTurn270_returnsWest()
        {
            map = new OpMap(m, Direction.N, 1, 1);
            map.turnRight();
            map.turnRight();
            map.turnRight();
            Assert.AreEqual(map.Direction, Direction.W);
        }

        [Test]
        public void clean_MarkX_returnsWest()
        {
            map = new OpMap(m, Direction.N, 1, 1);
            map.clean();
            Assert.AreEqual(m[1,1], Map.X);
        }

        [Test]
        public void advance_toColumn_throwCannotComplain()
        {
            map = new OpMap(m, Direction.E, 1, 1);
            Assert.Catch<CannotComplyException>(
                () => map.advance());
            Assert.AreEqual(map.XCoord, 1);
            Assert.AreEqual(map.YCoord, 1);
        }

        [Test]
        public void advance_toNull_throwCannotComplain()
        {
            map = new OpMap(m, Direction.S, 1, 2);
            Assert.Catch<CannotComplyException>(
                () => map.advance());
            Assert.AreEqual(map.XCoord, 1);
            Assert.AreEqual(map.YCoord, 2);
        }
    }
}
