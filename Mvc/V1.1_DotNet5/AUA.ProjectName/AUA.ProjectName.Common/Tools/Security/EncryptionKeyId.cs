using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using static System.Security.Cryptography.Rijndael;

namespace AUA.ProjectName.Common.Tools.Security
{
    public sealed class EncryptionKeyId
    {
        public static string Encrypt(string clearId, long userId)
        {
            var encryptionKey = userId + AppSetting.BaseEncryptionKeyId;


            var msgToPersist = Encoding.UTF8.GetBytes(clearId);
            var rndGen = RandomNumberGenerator.Create();

            var salt = new byte[32];
            rndGen.GetBytes(salt);

            var pdb = new Rfc2898DeriveBytes(encryptionKey, salt);
            var key = pdb.GetBytes(32);

            var algo = Create();
            algo.Key = key;
            var ms = new MemoryStream();
            ms.Write(salt, 0, salt.Length);
            ms.Write(algo.IV, 0, algo.IV.Length);
            var cs = new CryptoStream(ms, algo.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(msgToPersist, 0, msgToPersist.Length);
            cs.Close();
            var encryptedBytes = ms.ToArray();
            ms.Close();

            var encryptedMsgInBase64 = Convert.ToBase64String(encryptedBytes);


            return encryptedMsgInBase64;

        }
        public static string Decrypt(string cipherId, long userId)
        {
            var encryptionKey = userId + AppSetting.BaseEncryptionKeyId;

            try
            {

                var encryptedMsgInBase64 = cipherId.Replace(" ", "+");

                var encryptedBytes = Convert.FromBase64String(encryptedMsgInBase64);
                var algo = Create();
                var ms = new MemoryStream(encryptedBytes);
                var salt = new byte[32];
                ms.Read(salt, 0, salt.Length);
                var IV = new byte[algo.IV.Length];
                ms.Read(IV, 0, IV.Length);


                var db = new Rfc2898DeriveBytes(encryptionKey, salt);
                var key = db.GetBytes(32);
                algo.IV = IV;
                algo.Key = key;

                var cs = new CryptoStream(ms, algo.CreateDecryptor(), CryptoStreamMode.Read);
                var ms1 = new MemoryStream();
                var buffer = new byte[256];    //will be used as a buffer to get the decrypted data
                var bytesRead = 0;

                byte[] decryptedData = null;
                try
                {
                    do
                    {
                        bytesRead = cs.Read(buffer, 0, buffer.Length);
                        ms1.Write(buffer, 0, bytesRead);
                    } while (bytesRead > 0);

                    decryptedData = ms1.ToArray();
                    cs.Close();
                    ms.Close();
                    ms1.Close();
                }
                catch
                {

                    return string.Empty;
                }

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
