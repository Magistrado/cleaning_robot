using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot
{
    [Serializable]
    public class CannotComplyException : Exception
    {
        public CannotComplyException() : base() { }
    }

            

    public enum Map
    {
        S, C, N, X
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
        uint visitedCells= 0;
        uint cleanedCells = 0;

        public uint XCoord { get { return x_coor; } }
        public uint YCoord { get { return y_coor; } }
        public uint VisitedCells { get { return visitedCells; } }
        public uint CleanedCells { get { return cleanedCells; } }

        public Direction Direction { get { return facing; } }

        public OpMap(Map[,] map, Direction facing, uint x_ini, uint y_ini)
        {
            this.map = map;
            this.facing = facing;
            x_coor = x_ini;
            y_coor = y_ini;
        }

        public void advance()
        {
            switch ( facing )
            {
                case Direction.N:
                    if ( map[ y_coor - 1, x_coor] == Map.N 
                        || map[y_coor - 1, x_coor] == Map.C )
                    {
                        throw new CannotComplyException();
                    }
                    y_coor -= 1;
                    break;
                case Direction.W:
                    if ( map[y_coor, x_coor -1] == Map.N
                        || map[y_coor, x_coor -1] == Map.C )
                    {
                        throw new CannotComplyException();
                    }
                    x_coor -= 1;
                    break;
                case Direction.S:
                    if ( map[y_coor + 1, x_coor] == Map.N
                        || map[y_coor + 1, x_coor] == Map.C )
                    {
                        throw new CannotComplyException();
                    }
                    y_coor += 1;
                    break;
                case Direction.E:
                    if ( map[y_coor, x_coor + 1] == Map.N
                        || map[y_coor, x_coor + 1] == Map.C )
                    {
                        throw new CannotComplyException();
                    }
                    x_coor += 1;
                    break;
            }
        }

        public void back()
        {
            switch ( facing )
            {
                case Direction.N:
                    y_coor += 1;
                    break;
                case Direction.W:
                    x_coor += 1;
                    break;
                case Direction.S:
                    y_coor -= 1;
                    break;
                case Direction.E:
                    x_coor -= 1;
                    break;
            }
        }

        public void clean()
        {
            map[y_coor, x_coor] = Map.X;
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
