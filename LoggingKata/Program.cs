﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------



            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            string[] lines = File.ReadAllLines(csvPath);

            

            //logger.LogInfo($"Lines: {lines[0]}");- first item in Array


            // Create a new instance of your TacoParser class
            TacoParser parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            ITrackable[] locations = lines.Select(parser.Parse).ToArray();

            //List <ITrackable> tacoList = new List <ITrackable>();
            //foreach (var line in lines)
            //{
            //tacoList.Add(parser.Parse(lines));
            //}

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable tb1 = null;
            ITrackable tb2 = null;

            double distance = 0;



            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            for (int i = 0; i < locations.Length; i++)
            {
                ITrackable locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int x = 0; x < locations.Length; x++)
                {
                    var locB = locations[x];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);


                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tb1 = locA;
                        tb2 = locB;
                    }

                }

                


            }

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.


            logger.LogInfo($"{tb1.Name} and {tb2.Name} are the furthest Taco Bells apart from each other");
            Console.WriteLine($"They are {Math.Round(distance *.00062137,3)} miles apart");
        }
    }
}
