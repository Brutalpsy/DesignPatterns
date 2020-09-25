using System;
using System.Runtime.Serialization;

namespace Chain_of_Responsibility_First_Look.Handlers.UserValidation
{
    [Serializable]
    internal class UserValidationException : Exception
    {
        public UserValidationException()
        {
        }

        public UserValidationException(string message) : base(message)
        {
        }

        public UserValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}