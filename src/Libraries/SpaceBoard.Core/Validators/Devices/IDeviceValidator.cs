using System.Collections.Generic;

namespace SpaceBoard.Core.Validators.Devices
{
    public interface IDeviceValidator
    {
        void IsValidDeviceStartingPoint(IList<string> directions, string deviceStartingPoint, string separator = "");
        void IsValidDeviceMovements(IList<string> listOfMovements, string deviceMovements, string seperator = " ");
    }
}
