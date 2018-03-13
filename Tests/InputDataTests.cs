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
    class InputDataTests
    {
        [Test]
        public void parseToInputData_returnInputDataLoaded()
        {
            Map[,] m = new Map[,]
            {
                {Map.S, Map.S, Map.S, Map.S},
                {Map.S, Map.S, Map.C, Map.S},
                {Map.S, Map.S, Map.S, Map.S},
                {Map.S, Map.Null, Map.S, Map.S},
            };

            string input = "{\"map\": [[\"S\", \"S\", \"S\", \"S\"],[\"S\", \"S\", \"C\", \"S\"],[\"S\", \"S\", \"S\", \"S\"],[\"S\", \"null\", \"S\", \"S\"]],\"start\": {\"X\": 3, \"Y\": 0, \"facing\": \"N\"},\"commands\": [ \"TL\",\"A\",\"C\",\"A\",\"C\",\"TR\",\"A\",\"C\"],\"battery\": 80}";
            Command[] cmds = new Command[] { Command.TL, Command.A, Command.C, Command.A, Command.C, Command.TR, Command.A, Command.C };
            InputData id = InputData.parseToInputData(input);
            Assert.AreEqual(80, id.battery);
            Assert.AreEqual(cmds, id.commands);
            Assert.AreEqual(m, id.map);
            Assert.AreEqual(Direction.N, id.start.facing);
            Assert.AreEqual(3, id.start.X);
            Assert.AreEqual(0, id.start.Y);
        }
    }
}
