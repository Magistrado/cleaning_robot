using CleaningRobot;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class StatsTests
    {
        [Test]
        public void buildToJSON_ReturnsString()
        {
            List<Cell> lsC = new List<Cell>();
            List<Cell> lsV = new List<Cell>();
            lsC.Add(new Cell(1, 1));
            lsV.Add(new Cell(0, 0));
            Stats s = new Stats(lsV, lsC, 80, Direction.W, 9, 9);
            StringAssert.AreEqualIgnoringCase("{\"visited\":[{\"X\":0,\"Y\":0}],\"cleaned\":[{\"X\":1,\"Y\":1}],\"battery\":80,\"final\":{\"X\":9,\"Y\":9,\"facing\":1}}", s.outputToJSON() );
        }
    }
}
