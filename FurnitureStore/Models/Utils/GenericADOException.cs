using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FurnitureStore.Models.Utils
{
    [Serializable]
    public class GenericADOException : ADOException
    {
        public GenericADOException()
        {

        }
        public GenericADOException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public GenericADOException(string message, Exception innerException, string sql) : base(message, innerException, sql) { }
        public GenericADOException(string message, Exception innerException) : base(message, innerException) { }
    }
}