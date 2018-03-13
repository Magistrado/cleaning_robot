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
        S, C, Null, X
    }

    public enum Direction
    {
        N, W, S, E
    }

    public struct Cell
    {
        public int X;
        public int Y;

        public Cell(int x_coord, int y_coord)
        {
            this.X = x_coord;
            this.Y = y_coord;
        }
    }

    public class OpMap
    {
        Map[,] map = null;
        int x_coor = 0;
        int y_coor = 0;
        Direction facing;

        List<Cell> visitedCells = null;
        List<Cell> cleanedCells = null;

        public int XCoord { get { return x_coor; } }
        public int YCoord { get { return y_coor; } }
        public List<Cell> VisitedCells { get { return visitedCells; } }
        public List<Cell> CleanedCells { get { return cleanedCells; } }

        public Direction Direction { get { return facing; } }

        public OpMap(Map[,] map, Direction facing, int x_ini, int y_ini)
        {
            this.map = map;
            this.facing = facing;
            x_coor = x_ini;
            y_coor = y_ini;
            visitedCells = new List<Cell>();
            cleanedCells = new List<Cell>();
        }

        public void advance()
        {
            uint mov = 0;
            switch ( facing )
            {
                case Direction.N:
                    if ( y_coor - 1 < 0 || (map[ mov, x_coor] == Map.Null 
                        || map[mov, x_coor] == Map.C) )
                    {
                        throw new CannotComplyException();
                    }
                    y_coor -= 1;
                    break;
                case Direction.W:
                    if ( x_coor - 1 < 0 && (map[y_coor, x_coor - 1] == Map.Null
                        || map[y_coor, x_coor -1] == Map.C ))
                    {
                        throw new CannotComplyException();
                    }
                    x_coor -= 1;
                    break;
                case Direction.S:
                    if ( y_coor + 1 >= map.GetLength(1) || map[y_coor + 1, x_coor] == Map.Null
                        || map[y_coor + 1, x_coor] == Map.C )
                    {
                        throw new CannotComplyException();
                    }
                    y_coor += 1;
                    break;
                case Direction.E:
                    if ( x_coor + 1 >= map.GetLength(0) || map[y_coor, x_coor + 1] == Map.Null
                        || map[y_coor, x_coor + 1] == Map.C )
                    {
                        throw new CannotComplyException();
                    }
                    x_coor += 1;
                    break;
            }

            if ( !visitedCells.Exists(c => c.X == x_coor && c.Y == y_coor))
            {
                visitedCells.Add(new Cell(y_coor, x_coor));
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
            visitedCells.Add(new Cell(y_coor, x_coor));
        }

        public void clean()
        {
            //map[y_coor, x_coor] = Map.X;
            cleanedCells.Add(new Cell(y_coor, x_coor));
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
