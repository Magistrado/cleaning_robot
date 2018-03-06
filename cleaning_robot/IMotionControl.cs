using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    [Serializable]
    public class OutOfBatteryException : Exception
    {
        public OutOfBatteryException() : base() { }
    }

    [Serializable]
    public class NotEnoughBatteryException : Exception
    {
        public NotEnoughBatteryException() : base(){ }
    }

    public interface IMotionControl
    {
        int Battery { get; }

        void advance();

        void back();

        void clean();

        void turnRight();

        void turnLeft();
    }
}
