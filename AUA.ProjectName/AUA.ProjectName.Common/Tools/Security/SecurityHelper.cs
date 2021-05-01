using System;
using System.Security.Cryptography;

namespace AUA.ProjectName.Common.Tools.Security
{
    public static class SecurityHelper
    {

        public static Guid CreateCryptographicallySecureGuid()
        {
            var rand = RandomNumberGenerator.Create();

            var bytes = new byte[16];
            rand.GetBytes(bytes);
            return new Guid(bytes);
        }

        public static string GetHashGuid()
        {
            return EncryptionHelper
                   .GetSha256Hash(CreateCryptographicallySecureGuid().ToString());
        }
    }
}
