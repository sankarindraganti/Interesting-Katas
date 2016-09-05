using System;
using System.Collections.Generic;

namespace SafestPlaceInGalaxy
{
    public class Attempt
    {
        public List<Location> Locations { get; set; }

        private int _numberOfLocations;

        public int NumberOfLocations
        {
            get { return _numberOfLocations; }
            set
            {
                if (!(value >= 1 && value <= 200))
                {
                    throw new ArgumentException("Number of Locations should be between 1 and 200 (both inclusive).");
                }
                _numberOfLocations = value;
            }
        }

        public long GetSafestDistance()
        {
            //Sort the locations of the bombs
            Locations.Sort();

            long maxDistance = 0;
            Location point1 = null, point2 =null;

            //Find the plan with maximum distance between the bombs
            for (var i = 0; i < Locations.Count - 1; i++)
            {
                var distance = Locations[i].CalculateDistance(Locations[i + 1]);
                if (maxDistance < distance)
                {
                    maxDistance = distance;
                    point1 = Locations[i];
                    point2 = Locations[i + 1];
                }
            }

            //Calculate MidPoint of the plan between the points with maximum distance
            if (point1 != null)
            {
                var midPoint = new Location()
                {
                    X = (point1.X + point2.X)/2,
                    Y = (point1.Y + point2.Y)/2,
                    Z = (point1.Z + point2.Z)/2
                };

                //Calculate the distance between the midpoint to one of the edges of the plane.
                return midPoint.CalculateDistance(point1);
            }

            return 0;
        }

        
    }
}
