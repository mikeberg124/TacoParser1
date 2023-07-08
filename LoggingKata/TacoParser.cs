namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            string [] cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("error, the array is less than 3 strings");

                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0-Done
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2


            var lat = double.Parse(cells[0]);
            var longi = double.Parse(cells[1]);
            var name = cells[2];

            // Your going to need to parse your string as a `double`-DOne
            // which is similar to parsing a string as an `int`



            // You'll need to create a TacoBell class-Done
            // that conforms to ITrackable

            TacoBell tacobell = new TacoBell();
            tacobell.Name = name;
            tacobell.Location = new Point { Latitude = lat, Longitude = longi };



            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly-Done

            return tacobell;

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable-Done

            
        }
    }
}