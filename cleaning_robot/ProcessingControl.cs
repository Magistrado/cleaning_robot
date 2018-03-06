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

        private void advance(Direction t) 
        {
            if ( t == Direction.N || t == Direction.S )
            {
                map.XCoor += 1;
            } else
            {
                map.YCoor += 1;
            }
        }

        private void back(Direction t)
        {
            if ( t == Direction.N || t == Direction.S )
            {
                map.YCoor -= 1;
            }
            else
            {
                map.YCoor -= 1;
            }
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
                            motCtrl.turnLeft();
                            break;
                        case Command.TR:
                            motCtrl.turnRight();
                            break;
                        case Command.A:
                            advance(motCtrl.Direction);
                            motCtrl.advance();
                            break;
                        case Command.B:
                            back(motCtrl.Direction);
                            motCtrl.back();
                            break;
                        case Command.C:
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
