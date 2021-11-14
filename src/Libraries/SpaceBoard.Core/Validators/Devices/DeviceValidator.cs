using SpaceBoard.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SpaceBoard.Core.Validators.Devices
{
    public class DeviceValidator : IDeviceValidator
    {
        public void IsValidDeviceStartingPoint(IList<string> listOfDirections, string deviceStartingPoint, string separator = "")
        {
            if(listOfDirections == null || listOfDirections.Count <= 0)
                throw new ArgumentNullException(null,"List of directions parameter cannot be null or empty");

            if(string.IsNullOrWhiteSpace(deviceStartingPoint))
                throw new ArgumentNullException(null,"Device starting point parameter cannot be null or empty");

            var directionsString = string.Join(separator, listOfDirections);
            var pattern = new Regex(@"^\d+ \d+ [" + directionsString + "]$").IsMatch(deviceStartingPoint);
            if(!pattern)
                throw new PatternValidationException("Direction parameters are not matching with device starting point format");

        }
        public void IsValidDeviceMovements(IList<string> listOfMovements, string deviceMovements, string seperator = " ")
        {
            if (listOfMovements == null || listOfMovements.Count <= 0)
                throw new ArgumentNullException(null,"List of movements parameter cannot be null or empty");

            if (string.IsNullOrWhiteSpace(deviceMovements))
                throw new ArgumentNullException(null,"Device movements parameter cannot be null or empty");

            var movementsString = string.Join(seperator, listOfMovements);
            var pattern = new Regex(@"^[" + movementsString + "]+$").IsMatch(deviceMovements);
            if (!pattern)
                throw new PatternValidationException("Movement parameters are not matching with device movements format");
        }


    }
}
