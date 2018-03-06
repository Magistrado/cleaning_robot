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

        [Test]
        public void back_batteryDecrease2_return2()
        {
            proc.back();
            Assert.AreEqual(2, proc.Battery);
        }

        [Test]
        public void clean_batteryDecrease5_return0()
        {
            proc.clean();
            Assert.AreEqual(0, proc.Battery);
        }

        [Test]
        public void turnLeft_batteryDecrease1_return4()
        {
            proc.turnLeft();
            Assert.AreEqual(4, proc.Battery);
        }

        [Test]
        public void turnRight_batteryDecrease1_return4()
        {
            proc.turnRight();
            Assert.AreEqual(4, proc.Battery);
        }

        [Test]
        public void turnRight_battery0_throwOutOfBattery()
        {
            IMotionControl procNoBat = new MotionControl(0);
            Assert.Catch<OutOfBatteryException>(
                () => procNoBat.turnRight());
        }

        [Test]
        public void turnLeft_battery0_throwOutOfBattery()
        {
            IMotionControl procNoBat = new MotionControl(0);
            Assert.Catch<OutOfBatteryException>(
                () => procNoBat.turnLeft());
        }

        [Test]
        public void advance_battery0_throwOutOfBattery()
        {
            IMotionControl procNoBat = new MotionControl(0);
            Assert.Catch<OutOfBatteryException>(
                () => procNoBat.advance());
        }

        [Test]
        public void back_battery0_throwOutOfBattery()
        {
            IMotionControl procNoBat = new MotionControl(0);
            Assert.Catch<OutOfBatteryException>(
                () => procNoBat.back());
        }

        [Test]
        public void clean_battery0_throwOutOfBattery()
        {
            IMotionControl procNoBat = new MotionControl(0);
            Assert.Catch<OutOfBatteryException>(
                () => procNoBat.clean());
        }

        [Test]
        public void clean_battery4_throwNotEnoughBattery()
        {
            IMotionControl procNoBat = new MotionControl(4);
            Assert.Catch<NotEnoughBatteryException>(
                () => procNoBat.clean());
        }

        [Test]
        public void clean_battery0_throwNotEnoughBattery()
        {
            IMotionControl procNoBat = new MotionControl(1);
            Assert.Catch<NotEnoughBatteryException>(
                () => procNoBat.clean());
        }

        [Test]
        public void advance_battery1_throwNotEnoughBattery()
        {
            IMotionControl procNoBat = new MotionControl(0);
            Assert.Catch<NotEnoughBatteryException>(
                () => procNoBat.advance());
        }

        [Test]
        public void back_battery0_throwNotEnoughBattery()
        {
            IMotionControl procNoBat = new MotionControl(2);
            Assert.Catch<NotEnoughBatteryException>(
                () => procNoBat.back());
        }
    }
}
