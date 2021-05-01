using System.Collections.Generic;

namespace AUA.ProjectName.Common.Exceptions
{
    public class ClientException : BusinessException
    {
      
        public ClientException(string key, string msg) : base(key, msg)
        {
        }

        public ClientException(List<KeyValuePair<string, string>> errors) : base(errors)
        {
        }
    }
}