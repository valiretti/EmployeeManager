using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeManager.Entities.Exceptions
{
    [Serializable]
    public class RelatedEntitiesExistException : Exception
    {
        public RelatedEntitiesExistException()
        {
        }

        public RelatedEntitiesExistException(string message) : base(message)
        {
        }

        public RelatedEntitiesExistException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RelatedEntitiesExistException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
