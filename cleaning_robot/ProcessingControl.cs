using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    enum Command
    {
        TL, TR, A, B, C
    }

    class ProcessingControl
    {
        Command[] cmds = null;
        IMotionControl motCtrl = null;
        OpMap map = null;
        bool error = false;

        public Command[] LoadCommands
        {
            set
            {
                cmds = value;
            }
        }

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
        }

        public void execProgram()
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

    }
}
