using System;

namespace DiscountCards.Core
{
    public class ValidationException : Exception
    {
        public object Value { get; }

        public ValidationException(string message) : base(message)
        {

        }

        public ValidationException(string message, object value) : base(message)
        {
            Value = value;
        }
    }
}