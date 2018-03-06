using System;
using NUnit.Framework;
using CleaningRobot;

namespace Tests
{
    [TestFixture]
    public class MotionControlTests
    {
        IMotionControl proc = null;
        [SetUp]
        public void init()
        {
            proc = new MotionControl(5);
        }

        [Test]
        public void advance_batteryDecrease2_return3()
        {
            proc.advance();
            Assert.AreEqual(3, proc.Battery);
        }

        public void back_batteryDecrease2_return2()
        {
            proc.back();
            Assert.AreEqual(2, proc.Battery);
        }

        public void clean_batteryDecrease5_return0()
        {
            proc.clean();
            Assert.AreEqual(0, proc.Battery);
        }

        public void turnLeft_batteryDecrease1_return4()
        {
            proc.turnLeft();
            Assert.AreEqual(4, proc.Battery);
        }

        public void turnRight_batteryDecrease1_return4()
        {
            proc.turnRight();
            Assert.AreEqual(4, proc.Battery);
        }
    }
}
