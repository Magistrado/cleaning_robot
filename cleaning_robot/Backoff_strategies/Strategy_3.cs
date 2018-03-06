using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot.Backoff_strategies
{
    public class Strategy_3 : IBackoffStrategy
    {
        // (TL, TL, A)
        public bool execStrategy(OpMap m, IMotionControl mc)
        {
            try
            {
                m.turnLeft();
                mc.turnLeft();

                m.turnLeft();
                mc.turnLeft();

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
