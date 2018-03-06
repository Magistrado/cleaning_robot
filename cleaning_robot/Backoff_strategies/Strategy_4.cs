using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot.Backoff_strategies
{
    public class Strategy_4 : IBackoffStrategy
    {
        // (TR, B, TR, A)
        public bool execStrategy(OpMap m, IMotionControl mc)
        {
            try
            {
                m.turnRight();
                mc.turnRight();

                m.back();
                mc.back();

                m.turnRight();
                mc.turnRight();

                m.advance();
                mc.advance();
            }
            catch ( CannotComplyException )
            {
                return false;
            }
            catch ( NotEnoughBatteryException )
            {
                return false;
            }
            catch ( OutOfBatteryException )
            {
                return false;
            }
            catch ( Exception )
            {
                return false;
            }
            return true;
        }
    }
}

