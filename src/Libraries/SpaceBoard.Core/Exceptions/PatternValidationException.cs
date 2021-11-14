using System;

namespace SpaceBoard.Core.Exceptions
{
    /// <summary>
    /// Represents the expcetion type of pattern validation exception
    /// </summary>
    public class PatternValidationException : Exception
    {
        public PatternValidationException(string message) : base(message)
        {
        }
    }
}
