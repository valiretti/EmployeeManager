using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeManager.Entities.Exceptions
{
    [Serializable]
    public class UniquenessViolationException : Exception
    {
        public UniquenessViolationException()
        {
        }

        public UniquenessViolationException(string message) : base(message)
        {
        }

        public UniquenessViolationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UniquenessViolationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
