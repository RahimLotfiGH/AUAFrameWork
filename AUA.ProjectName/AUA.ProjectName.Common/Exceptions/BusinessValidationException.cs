using System;
using System.Collections.Generic;

namespace AUA.ProjectName.Common.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public IList<string> MessageException { get; set; }
        public BusinessValidationException(IList<string> messages) : base(string.Join(",", messages))
        {
            MessageException = messages;
        }

        public BusinessValidationException(string message) : base(message)
        {
            MessageException = new List<string> { message };
        }
    }
}
