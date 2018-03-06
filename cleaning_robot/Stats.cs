using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public struct PositionFacing
    {
        public uint X;
        public uint Y;
        public Direction facing;

        public PositionFacing(uint x_lastPos, uint y_lastPos, Direction dir)
        {
            X = x_lastPos;
            Y = y_lastPos;
            facing = dir;
        }
    }

    public class Stats
    {
        Cell[] _visited = null;
        Cell[] _cleaned = null;
        uint _battery = 0;
        PositionFacing _lastPos;

        public Cell[] visited
        {
            get
            {
                return _visited;
            }

            set
            {
                this.visited = value;
            }
        }

        public Cell[] cleaned
        {
            get
            {
                return _cleaned;
            }

            set
            {
                this._cleaned = value;
            }
        }

        public uint battery
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

        public PositionFacing final
        {
            get
            {
                return _lastPos;
            }

            set
            {
                this._lastPos = value;
            }
        }

        public Stats(List<Cell> visitedCells, List<Cell> cleanedCells, uint battery, Direction dir, uint x_lastPos, uint y_lastPos)
        {
            this._visited = visitedCells.ToArray();
            this._cleaned = cleanedCells.ToArray();
            this._battery = battery;
            final = new PositionFacing(x_lastPos, y_lastPos, dir);
        }

        public string outputToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
