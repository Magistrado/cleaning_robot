using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    public enum Map
    {
        S, C, NULL, X
    }

    public enum Direction
    {
        N, W, S, E
    }

    public class OpMap
    {
        Map[,] map = null;
        uint x_coor = 0;
        uint y_coor = 0;
        Direction facing; 

        public uint XCoord { get; }
        public uint YCoord { get; }

        public Direction Direction { get { return facing; } }

        public OpMap(Map[,] map, Direction facing)
        {
            this.map = map;
            this.facing = facing;
        }

        public void advance()
        {
            if ( facing == Direction.N || facing == Direction.S )
            {
                x_coor += 1;
            }
            else
            {
                y_coor += 1;
            }
        }

        public void clean()
        {
            map[y_coor, x_coor] = Map.X;
        }

        private void back(Direction t)
        {
            if ( facing == Direction.N || facing == Direction.S )
            {
                x_coor -= 1;
            }
            else
            {
                y_coor -= 1;
            }
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
                    facing = Direction.W;
                    break;
                case Direction.W:
                    facing = Direction.S;
                    break;
                case Direction.S:
                    facing = Direction.E;
                    break;
                case Direction.E:
                    facing = Direction.N;
                    break;
            }
        }

    }

}
