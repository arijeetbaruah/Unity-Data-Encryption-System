using System;
using System.Security.Cryptography;
using System.Text;

namespace Baruah.EncryptionSystem
{
    public class AESEncryptionSystem: BaseEncryptionSystem
    {
        private string key;
        private string iv;

        public AESEncryptionSystem(string key, string iv)
        {
            this.key = key;
            this.iv = iv;
        }

        public override byte[] EncryptAsByte(string inputData)
        {
            AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
            AEScryptoProvider.BlockSize = 128;
            AEScryptoProvider.KeySize = 256;
            AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
            AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(iv);
            AEScryptoProvider.Mode = CipherMode.CBC;
            AEScryptoProvider.Padding = PaddingMode.PKCS7;

            byte[] txtByteData = ASCIIEncoding.ASCII.GetBytes(inputData);
            ICryptoTransform trnsfrm = AEScryptoProvider.CreateEncryptor(AEScryptoProvider.Key, AEScryptoProvider.IV);

            return trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
            //return Convert.ToBase64String(result);
        }

        public override byte[] DecryptAsByte(string inputData)
        {
            AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
            AEScryptoProvider.BlockSize = 128;
            AEScryptoProvider.KeySize = 256;
            AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
            AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(iv);
            AEScryptoProvider.Mode = CipherMode.CBC;
            AEScryptoProvider.Padding = PaddingMode.PKCS7;

            byte[] txtByteData = Convert.FromBase64String(inputData);
            ICryptoTransform trnsfrm = AEScryptoProvider.CreateDecryptor();

            return trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
            //return ASCIIEncoding.ASCII.GetString(result);
        }
    }
}
