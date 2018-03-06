using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningRobot;

namespace CleaningRobot.Backoff_strategies
{
    public class Strategy_1 : IBackoffStrategy
    {
        public bool execStrategy(OpMap m, IMotionControl mc)
        {
            try
            {
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
