using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Baruah.EncryptionSystem
{
    public class DESEncryptionSystem : BaseEncryptionSystem
    {
        private string key;

        public DESEncryptionSystem(string key)
        {
            this.key = key;
        }

        public override byte[] DecryptAsByte(string inputData)
        {
            byte[] txtByteData = Convert.FromBase64String(inputData);
            byte[] keyByteData = ASCIIEncoding.ASCII.GetBytes(key);

            DESCryptoServiceProvider DEScryptoProvider = new DESCryptoServiceProvider();
            ICryptoTransform trnsfrm = DEScryptoProvider.CreateDecryptor(keyByteData, keyByteData);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            //Set up Stream & Write Encript data
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, trnsfrm, mode);
            cStream.Write(txtByteData, 0, txtByteData.Length);
            cStream.FlushFinalBlock();

            //Read Ecncrypted Data From Memory Stream
            byte[] result = new byte[mStream.Length];
            mStream.Position = 0;
            mStream.Read(result, 0, result.Length);

            return result;
            //return ASCIIEncoding.ASCII.GetString(result);
        }

        public override byte[] EncryptAsByte(string inputData)
        {
            byte[] txtByteData = ASCIIEncoding.ASCII.GetBytes(inputData);
            byte[] keyByteData = ASCIIEncoding.ASCII.GetBytes(key);

            DESCryptoServiceProvider DEScryptoProvider = new DESCryptoServiceProvider();
            ICryptoTransform trnsfrm = DEScryptoProvider.CreateEncryptor(keyByteData, keyByteData);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            //Set up Stream & Write Encript data
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, trnsfrm, mode);
            cStream.Write(txtByteData, 0, txtByteData.Length);
            cStream.FlushFinalBlock();

            //Read Ecncrypted Data From Memory Stream
            byte[] result = new byte[mStream.Length];
            mStream.Position = 0;
            mStream.Read(result, 0, result.Length);

            return result;
            //return Convert.ToBase64String(result);
        }
    }
}
