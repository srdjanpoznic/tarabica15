using System;

namespace Tarabica15.WebAPI.Contracts.Exceptions
{
    [Serializable]
    public class AuthenticationServiceException : Exception
    {
        public AuthenticationServiceException()
        {
        }

        public AuthenticationServiceException(string message)
            : base(message)
        {
        }

        public AuthenticationServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}