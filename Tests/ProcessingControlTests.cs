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
    class ProcessingControlTests
    {
        OpMap map = null;
        Map[,] m = null;
        IMotionControl motCtrl = null;
        ProcessingControl proc = null;

        [SetUp]
        public void init()
        {
            // Test_1
            m = new Map[,]
            {
                {Map.S, Map.S, Map.S, Map.S},
                {Map.S, Map.S, Map.C, Map.S},
                {Map.S, Map.S, Map.S, Map.S},
                {Map.S, Map.N, Map.S, Map.S},
            };
            map = new OpMap(m, Direction.N, 3, 0);
            motCtrl = new MotionControl(10);
            
            proc = new ProcessingControl(motCtrl);
        }

        [Test]
        public void execProgram_VerifyingPositionFacing_returnTrue()
        {
            proc.LoadMap = map;
            Command[] cmds = new Command[] { Command.TL, Command.A, Command.C, Command.A};
            proc.execProgram(cmds);
            Assert.AreEqual(map.Direction, Direction.W);
            Assert.AreEqual(map.XCoord, 1);
            Assert.AreEqual(map.YCoord, 0);
        }

        [Test]
        public void execProgram_NoBatteryLeft_returnErrorTrue()
        {
            proc.LoadMap = map;
            Command[] cmds = new Command[] { Command.TL, Command.A, Command.C, Command.A, Command.C };
            proc.execProgram(cmds);
            Assert.IsTrue(proc.Error);
            Assert.AreEqual(map.Direction, Direction.W);
            Assert.AreEqual(map.XCoord, 1);
            Assert.AreEqual(map.YCoord, 0);
        }

        //[Test]
        //public void execProgram_Test1ValidConditions_returnTrue()
        //{
        //    proc.LoadMap = map;
        //    proc.LoadCommands = new Command[] { Command.TL, Command.A, Command.C, Command.A, Command.C, Command.TR, Command.A, Command.C };
        //    proc.execProgram();
        //    Assert.AreEqual(map.Direction, Direction.E);

        //}
    }
}
