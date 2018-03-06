using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public class MotionControl : IMotionControl
    {
        private uint battery = 0;
        private Direction facing = Direction.N;

        public MotionControl(uint battery)
        {
            this.battery = battery;
        }

        public uint Battery
        {
            get
            {
                return battery;
            }
        }

        public void advance()
        {
            if ( battery <= 0 )
                throw new OutOfBatteryException();
            battery -= 2;
        }

        public void back()
        {
            if ( battery <= 0 )
                throw new OutOfBatteryException();
            battery -= 3;
        }

        public void clean()
        {
            if ( battery <= 0 )
                throw new OutOfBatteryException();
            battery -= 5;
        }

        public void turnRight()
        {
            if ( battery <= 0 )
                throw new OutOfBatteryException();

            
        }

        public void turnLeft()
        {
            if ( battery <= 0 )
                throw new OutOfBatteryException();
            battery -= 1;
        }
    }
}
