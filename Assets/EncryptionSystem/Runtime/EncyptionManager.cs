using System;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Baruah.EncryptionSystem.Manager
{
    [AddComponentMenu("Encryption System/Encryption Manager")]
    public class EncyptionManager : MonoBehaviour
    {
        public static EncyptionManager manager;

        public EncryptionType encryptionType;

        public string AEC_key = "A60A5770FE5E7AB200BA9CFC94E4E8B0";
        public string AEC_iv = "1234567887654321";
        public string DES_key = "ABCDEFGH";
        public string MD5_key = "Password@username:userID";

        public BaseEncryptionSystem encryptionSystem = null;

        private void Awake()
        {
            if (manager == null)
            {
                manager = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            switch (encryptionType)
            {
                case EncryptionType.AES:
                    encryptionSystem = new AESEncryptionSystem(AEC_key, AEC_iv);
                    break;
                case EncryptionType.DES:
                    encryptionSystem = new DESEncryptionSystem(DES_key);
                    break;
                case EncryptionType.MD5:
                    encryptionSystem = new MD5EncryptionSystem(MD5_key);
                    break;
            }
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

        public byte[] EncryptAsByte(string inputData)
        {
            return encryptionSystem.EncryptAsByte(inputData);
        }

        public byte[] DecryptAsByte(string inputData)
        {
            return encryptionSystem.DecryptAsByte(inputData);
        }

        public string EncryptAsString(string inputData)
        {
            return Convert.ToBase64String(EncryptAsByte(inputData));
        }

        public string DecryptAsString(string inputData)
        {
            return ASCIIEncoding.ASCII.GetString(DecryptAsByte(inputData));
        }

        //private bool staticKey = false;

        //[MenuItem("Tool/Encryption Setting")]
        //static void Init()
        //{
        //    // Get existing open window or if none, make a new one:
        //    EncyptionManager window = (EncyptionManager)EditorWindow.GetWindow(typeof(EncyptionManager));
        //    window.Show();
        //}

        //void OnGUI()
        //{
        //    var oldEncryptionType = (EncryptionType)PlayerPrefs.GetInt("encryptionType");
        //    encryptionType = oldEncryptionType;
        //    encryptionType = (EncryptionType)EditorGUILayout.EnumPopup("Encryption Type", encryptionType);
        //    if (oldEncryptionType != encryptionType)
        //    {
        //        PlayerPrefs.SetInt("encryptionType", (int)encryptionType);
        //    }

        //    switch (encryptionType)
        //    {
        //        case EncryptionType.AES:
        //            var oldAECKey = PlayerPrefs.GetString("AEC_key");
        //            var oldAECIv = PlayerPrefs.GetString("AEC_iv");
        //            AEC_iv = oldAECIv;
        //            AEC_key = oldAECKey;

        //            AEC_key = EditorGUILayout.TextField("Key", AEC_key);
        //            AEC_iv = EditorGUILayout.TextField("iv", AEC_iv);

        //            if (AEC_key != oldAECKey)
        //            {
        //                PlayerPrefs.SetString("AEC_key", AEC_key);
        //            }
        //            if (AEC_iv != oldAECIv)
        //            {
        //                PlayerPrefs.SetString("AEC_iv", AEC_iv);
        //            }
        //            break;
        //        case EncryptionType.DES:
        //            var oldDESKey = PlayerPrefs.GetString("DES_key");

        //            DES_key = EditorGUILayout.TextField("Key", DES_key);

        //            if (oldDESKey != DES_key)
        //            {
        //                PlayerPrefs.SetString("DES_key", DES_key);
        //            }
        //            break;
        //        case EncryptionType.MD5:
        //            staticKey = PlayerPrefs.GetInt("StaticKey") == 1;
        //            staticKey = EditorGUILayout.Toggle("Use Static Key", staticKey);
        //            PlayerPrefs.SetInt("StaticKey", staticKey ? 1 : 0);
        //            if (staticKey)
        //            {
        //                var oldMD5Key = PlayerPrefs.GetString("MD5_key");
        //                MD5_key = EditorGUILayout.TextField("Key", DES_key);

        //                if (oldMD5Key != MD5_key)
        //                {
        //                    PlayerPrefs.SetString("MD5_key", MD5_key);
        //                }
        //            }
        //            break;
        //    }

        //    //GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        //    //myString = EditorGUILayout.TextField("Text Field", myString);

        //    //groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        //    //myBool = EditorGUILayout.Toggle("Toggle", myBool);
        //    //myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        //    //EditorGUILayout.EndToggleGroup();
        //}
    }
}
