using CleaningRobot.Backoff_strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public enum Command
    {
        TL, TR, A, B, C
    }

    public class ProcessingControl
    {
        IMotionControl motCtrl = null;
        OpMap map = null;
        bool error = false;
        protected List<IBackoffStrategy> bsLs = null;

        public bool Error { get { return error; } }

        public OpMap LoadMap
        {
            set
            {
                map = value;
            }
        }

        public ProcessingControl(IMotionControl motCtrl)
        {
            if ( motCtrl == null )
                throw new ArgumentNullException("motCtrl");

            this.motCtrl = motCtrl;
            bsLs = new List<IBackoffStrategy>();
            fillBackOffStrategies();
        }

        public ProcessingControl(IMotionControl motCtrl, OpMap map)
        {
            if ( motCtrl == null )
                throw new ArgumentNullException("motCtrl");

            this.motCtrl = motCtrl;
            this.map = map;
            bsLs = new List<IBackoffStrategy>();
            this.fillBackOffStrategies();
        }


        public void execProgram(Command[] cmds)
        {
            foreach ( Command inst in cmds )
            {
                try
                {
                    switch ( inst )
                    {
                        case Command.TL:
                            map.turnLeft();
                            motCtrl.turnLeft();
                            break;
                        case Command.TR:
                            map.turnRight();
                            motCtrl.turnRight();
                            break;
                        case Command.A:
                            map.advance();
                            motCtrl.advance();
                            break;
                        case Command.B:
                            map.back();
                            motCtrl.back();
                            break;
                        case Command.C:
                            map.clean();
                            motCtrl.clean();
                            break;
                    }
                }
                catch ( CannotComplyException )
                {
                    execBackoff();
                    if ( error )
                    {
                        // Execution finished
                        return;
                    }
                }
                catch ( NotEnoughBatteryException )
                {
                    error = true;
                }
                catch ( OutOfBatteryException )
                {
                    error = true;
                }
                catch ( Exception )
                {
                    error = true;
                }
            }  
        }

        protected virtual void fillBackOffStrategies()
        {
            bsLs.Add(new Strategy_1());
        }

        private void execBackoff()
        {
            foreach ( IBackoffStrategy bs in bsLs)
            {
                if ( bs.execStrategy(map, motCtrl) )
                {
                    error = false;
                    return;
                } 
            }
        }

    }
}
