using System;
using System.Security.Cryptography;
using System.Text;

namespace Baruah.EncryptionSystem
{
    public class MD5EncryptionSystem : BaseEncryptionSystem
    {
        private string key;

        public MD5EncryptionSystem(string key)
        {
            this.key = key;
        }

        public string Key
        {
            set
            {
                key = value;
            }
        }

        public override byte[] DecryptAsByte(string inputData)
        {
            byte[] bData = Convert.FromBase64String(inputData);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripalDES = new TripleDESCryptoServiceProvider();

            tripalDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            tripalDES.Mode = CipherMode.ECB;

            ICryptoTransform trnsfrm = tripalDES.CreateDecryptor();
            return trnsfrm.TransformFinalBlock(bData, 0, bData.Length);

            //return UTF8Encoding.UTF8.GetString(result);
        }

        public override byte[] EncryptAsByte(string inputData)
        {
            byte[] bData = UTF8Encoding.UTF8.GetBytes(inputData);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripalDES = new TripleDESCryptoServiceProvider();

            tripalDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            tripalDES.Mode = CipherMode.ECB;

            ICryptoTransform trnsfrm = tripalDES.CreateEncryptor();
            return trnsfrm.TransformFinalBlock(bData, 0, bData.Length);

            //return Convert.ToBase64String(result);
        }
    }
}
