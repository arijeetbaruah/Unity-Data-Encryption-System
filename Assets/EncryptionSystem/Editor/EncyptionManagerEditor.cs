using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Baruah.EncryptionSystem.Manager
{
    [CustomEditor(typeof(EncyptionManager))]
    public class EncyptionManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EncyptionManager manager = (EncyptionManager)target;
            manager.encryptionType = (EncryptionType) EditorGUILayout.EnumPopup("Encryption Type", manager.encryptionType);

            switch (manager.encryptionType)
            {
                case EncryptionType.AES:
                    manager.AEC_key = EditorGUILayout.TextField("Key", manager.AEC_key);
                    manager.AEC_iv = EditorGUILayout.TextField("IV", manager.AEC_iv);
                    break;
                case EncryptionType.DES:
                    manager.DES_key = EditorGUILayout.TextField("Key", manager.DES_key);
                    break;
                case EncryptionType.MD5:
                    manager.MD5_key = EditorGUILayout.TextField("Key", manager.MD5_key);
                    break;
            }
        }
    }
}
