using System;
using System.Text;
using UnityEngine;

namespace Baruah.EncryptionSystem
{
    public enum EncryptionType
    {
        AES,
        MD5,
        DES
    }

    public abstract class BaseEncryptionSystem
    {
        public static BaseEncryptionSystem instance;

        public BaseEncryptionSystem()
        {
            instance = this;
        }

        public T Encrypt<T>(string inputData) where T : class
        {
            if (typeof(T) == typeof(string))
                return EncryptAsString(inputData) as T;

            if (typeof(T) == typeof(byte[]))
                return EncryptAsByte(inputData) as T;

            return null;
        }

        public T Decrypt<T>(string inputData) where T : class
        {
            if (typeof(T) == typeof(string))
                return DecryptAsString(inputData) as T;

            if (typeof(T) == typeof(byte[]))
                return DecryptAsByte(inputData) as T;

            return null;
        }

        public abstract byte[] EncryptAsByte(string inputData);
        public abstract byte[] DecryptAsByte(string inputData);

        public string EncryptAsString(string inputData)
        {
            return Convert.ToBase64String(EncryptAsByte(inputData));
        }

        public string DecryptAsString(string inputData)
        {
            return ASCIIEncoding.ASCII.GetString(DecryptAsByte(inputData));
        }
    }
}
