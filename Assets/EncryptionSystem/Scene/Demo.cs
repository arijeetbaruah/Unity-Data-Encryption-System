using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using Baruah.EncryptionSystem.Manager;

namespace Baruah.EncryptionSystem
{
    public class Demo : MonoBehaviour
    {
        public TMP_InputField inputTxt;
        public TMP_InputField outputTxt;

        public void Encrypt()
        {
            outputTxt.text = EncyptionManager.manager.Encrypt<string>(inputTxt.text);
        }

        public void Decrypt()
        {
            outputTxt.text = EncyptionManager.manager.Decrypt<string>(inputTxt.text);
        }
    }
}
