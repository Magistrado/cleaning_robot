using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public class InputData
    {
        int _battery = 0;
        PositionFacing _start;
        Map[,] _map = null;
        Command[] _cmds = null;

        public int battery
        {
            get
            {
                return _battery;
            }

            set
            {
                this._battery = value;
            }
        }

        public PositionFacing start
        {
            get
            {
                return _start;
            }

            set
            {
                this._start = value;
            }
        }

        public Map[,] map
        {
            get
            {
                return _map;
            }

            set
            {
                this._map = value;
            }
        }

        public Command[] commands
        {
            get
            {
                return _cmds;
            }

            set
            {
                this._cmds = value;
            }
        }

        public static InputData parseToInputData(string data)
        {
            return JsonConvert.DeserializeObject<InputData>(data);
        }
    }
}
