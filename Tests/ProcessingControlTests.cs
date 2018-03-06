using CleaningRobot;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningRobot.Backoff_strategies;

namespace Tests
{
    class WithStrategy_1 : ProcessingControl
    {
        public WithStrategy_1(IMotionControl motCtrl, OpMap m) : base(motCtrl,m) { }

        protected override void fillBackOffStrategies()
        {
            this.bsLs.Add(new Strategy_1());
        }
    }

    class WithStrategy_2 : ProcessingControl
    {
        public WithStrategy_2(IMotionControl motCtrl, OpMap m) : base(motCtrl, m) { }

        protected override void fillBackOffStrategies()
        {
            this.bsLs.Add(new Strategy_2());
        }
    }


    class WithStrategy_3 : ProcessingControl
    {
        public WithStrategy_3(IMotionControl motCtrl, OpMap m) : base(motCtrl, m) { }

        protected override void fillBackOffStrategies()
        {
            this.bsLs.Add(new Strategy_3());
        }
    }

    class WithStrategy_4 : ProcessingControl
    {
        public WithStrategy_4(IMotionControl motCtrl, OpMap m) : base(motCtrl, m) { }

        protected override void fillBackOffStrategies()
        {
            this.bsLs.Add(new Strategy_4());
        }
    }

    class WithStrategy_5 : ProcessingControl
    {
        public WithStrategy_5(IMotionControl motCtrl, OpMap m) : base(motCtrl, m) { }

        protected override void fillBackOffStrategies()
        {
            this.bsLs.Add(new Strategy_5());
        }
    }



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

        [Test]
        public void execProgram_advanceToColumnBackoff1_returnErrorFalse()
        {
            map = new OpMap(m, Direction.S, 2, 0);
            proc = new WithStrategy_1(motCtrl, map);
            Command[] cmds = new Command[] { Command.A };
            proc.execProgram(cmds);
            Assert.IsFalse(proc.Error);
            Assert.AreEqual(map.Direction, Direction.W);
            Assert.AreEqual(map.XCoord, 0);
            Assert.AreEqual(map.YCoord, 0);
        }

        [Test]
        public void execProgram_advanceToColumnBackoff2_returnErrorFalse()
        {
            map = new OpMap(m, Direction.N, 2, 2);
            proc = new WithStrategy_2(motCtrl, map);
            Command[] cmds = new Command[] { Command.A };
            proc.execProgram(cmds);
            Assert.IsFalse(proc.Error);
            Assert.AreEqual(map.Direction, Direction.N);
            Assert.AreEqual(map.XCoord, 3);
            Assert.AreEqual(map.YCoord, 0);
        }

        [Test]
        public void execProgram_advanceToColumnBackoff3_returnErrorFalse()
        {
            m[3, 3] = Map.C;
            map = new OpMap(m, Direction.S, 3, 2);
            proc = new WithStrategy_3(motCtrl, map);
            Command[] cmds = new Command[] { Command.A };
            proc.execProgram(cmds);
            Assert.IsFalse(proc.Error);
            Assert.AreEqual(map.Direction, Direction.N);
            Assert.AreEqual(map.XCoord, 3);
            Assert.AreEqual(map.YCoord, 0);
        }

        [Test]
        public void execProgram_advanceToColumnBackoff4_returnErrorFalse()
        {
            m[3, 2] = Map.C;
            map = new OpMap(m, Direction.S, 2, 2);
            proc = new WithStrategy_4(motCtrl, map);
            Command[] cmds = new Command[] { Command.A };
            proc.execProgram(cmds);
            Assert.IsFalse(proc.Error);
            Assert.AreEqual(map.Direction, Direction.N);
            Assert.AreEqual(map.XCoord, 3);
            Assert.AreEqual(map.YCoord, 0);
        }

        [Test]
        public void execProgram_advanceToNullBackoff5_returnErrorFalse()
        {
            m[3, 3] = Map.N;
            map = new OpMap(m, Direction.S, 3, 2);
            proc = new WithStrategy_5(motCtrl, map);
            Command[] cmds = new Command[] { Command.A };
            proc.execProgram(cmds);
            Assert.IsFalse(proc.Error);
            Assert.AreEqual(map.Direction, Direction.N);
            Assert.AreEqual(map.XCoord, 3);
            Assert.AreEqual(map.YCoord, 0);
        }

        /*
        [Test]
        public void execProgram_advanceToNullBackoff12345_returnErrorTrue()
        {
            m[3, 3] = Map.N;
            map = new OpMap(m, Direction.S, 3, 2);
            proc = new WithStrategy_5(motCtrl, map);
            Command[] cmds = new Command[] { Command.A };
            proc.execProgram(cmds);
            Assert.IsTrue(proc.Error);
            Assert.AreEqual(map.Direction, Direction.N);
            Assert.AreEqual(map.XCoord, 3);
            Assert.AreEqual(map.YCoord, 0);
        }    */

        [Test]
        public void execProgram_Test1ValidConditions_returnTrue()
        {
            map = new OpMap(m, Direction.N, 3, 0);
            motCtrl = new MotionControl(80);

            proc = new ProcessingControl(motCtrl);
            proc.LoadMap = map;
            Command[] cmds = new Command[] { Command.TL, Command.A, Command.C, Command.A, Command.C, Command.TR, Command.A, Command.C };

            proc.execProgram(cmds);
            Assert.AreEqual(54, motCtrl.Battery);
            Assert.AreEqual(Direction.E, map.Direction);
            Assert.AreEqual(2, map.XCoord);
            Assert.AreEqual(0, map.YCoord);
        }
    }
}
