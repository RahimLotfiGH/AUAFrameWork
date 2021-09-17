using System.Collections.Generic;

namespace AUA.ProjectName.Common.Exceptions
{
    public class ServerException : BusinessException
    {
        public ServerException(string key, string msg) : base(key, msg)
        {
        }

        public ServerException(List<KeyValuePair<string, string>> errors) : base(errors)
        {
        }
    }
}