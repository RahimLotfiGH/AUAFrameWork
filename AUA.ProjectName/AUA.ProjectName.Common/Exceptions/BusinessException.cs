using System.Collections.Generic;
using System.Linq;

namespace AUA.ProjectName.Common.Exceptions
{
    public class BusinessException : BusinessValidationException
    {
        public List<KeyValuePair<string, string>> Errors { get; set; }

        public BusinessException(string key, string msg) : base(msg)
        {
            Errors = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(key, msg)
            };

        }

        public BusinessException(List<KeyValuePair<string, string>> errors) : base(errors.Select(s => s.Value).ToList())
        {
            Errors = errors;
        }
    }
}
