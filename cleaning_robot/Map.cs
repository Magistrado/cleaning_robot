using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public enum Map
    {
        S, C, NULL
    }

    public enum Direction
    {
        N, W, S, E
    }

    public class OpMap
    {
        Map[,] map = null;
        public uint XCoor { get; set; }
        public uint YCoor { get; set; }
        public Direction facing; 

        public Direction Direction { get { return facing; } }

        public OpMap(Map[,] map, Direction facing)
        {
            this.map = map;
            facing = facing;
        }

        public void turnRight()
        {
            switch ( facing )
            {
                case Direction.N:
                    facing = Direction.E;
                    break;
                case Direction.W:
                    facing = Direction.N;
                    break;
                case Direction.S:
                    facing = Direction.W;
                    break;
                case Direction.E:
                    facing = Direction.S;
                    break;
            }
        }

        public void turnLeft()
        {
            switch ( Direction )
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;
                case Direction.W:
                    Direction = Direction.S;
                    break;
                case Direction.S:
                    Direction = Direction.E;
                    break;
                case Direction.E:
                    Direction = Direction.N;
                    break;
            }
        }

    }

}
