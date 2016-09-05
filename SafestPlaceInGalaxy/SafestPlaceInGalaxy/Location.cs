using System;
using System.Net;

namespace SafestPlaceInGalaxy
{
    public class Location : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int CompareTo(object obj)
        {
            var location = obj as Location;

            if (location != null && X == location.X)
            {
                if (Y == location.Y)
                {
                    if (Z == location.Z)
                    {
                        return 0;
                    }
                    else if (Z <= location.Z)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (Y <= location.Y)
                {
                    return -1;
                }
                else if(Y > location.Y)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (location != null && X <= location.X)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public long CalculateDistance(Location secondPoint)
        {
            return (X - secondPoint.X)*(X - secondPoint.X) + (Y - secondPoint.Y)*(Y - secondPoint.Y) + (Z - secondPoint.Z)*(Z - secondPoint.Z);
        }
    }
}
