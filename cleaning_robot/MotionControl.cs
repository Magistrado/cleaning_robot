using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public class MotionControl : IMotionControl
    {
        private int battery = 0;
        private Direction facing = Direction.N;

        public MotionControl(int battery)
        {
            this.battery = battery;
        }

        public int Battery
        {
            get
            {
                return battery;
            }
        }

        public void advance()
        {
            if ( ( battery - 2 ) < 0 )
                throw new NotEnoughBatteryException();

            if ( battery <= 0 )
                throw new OutOfBatteryException();
                                                      
            battery -= 2;
        }

        public void back()
        {
            if ( ( battery - 3 ) < 0 )
                throw new NotEnoughBatteryException();

            if ( battery <= 0 )
                throw new OutOfBatteryException();    

            battery -= 3;
        }

        public void clean()
        {
            if ( ( battery - 5 ) < 0 )
                throw new NotEnoughBatteryException();

            if ( battery <= 0 )
                throw new OutOfBatteryException();

            battery -= 5;
        }

        public void turnRight()
        {
            if ( ( battery - 1 ) < 0 )
                throw new NotEnoughBatteryException();

            if ( battery <= 0 )
                throw new OutOfBatteryException();

            battery -= 1;
        }

        public void turnLeft()
        {
            if ( ( battery - 1 ) < 0 )
                throw new NotEnoughBatteryException();

            if ( battery <= 0 )
                throw new OutOfBatteryException();

            battery -= 1;
        }
    }
}
