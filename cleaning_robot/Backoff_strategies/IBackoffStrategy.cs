using CleaningRobot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public interface IBackoffStrategy
    {
        bool execStrategy(OpMap m, IMotionControl mc);
    }
}
