using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Baruah.EncryptionSystem
{
    public class MD5EncryptionSystemTest
    {
        [Test]
        public void MD5EncryptionSystemTestSimplePasses()
        {
            new MD5EncryptionSystem("SomeKey");
            string val = "SomeThing";

            string result = MD5EncryptionSystem.instance.EncryptAsString("SomeThing");

            string revert = MD5EncryptionSystem.instance.DecryptAsString(result);
            Assert.True(Equals(revert, val));
        }
    }
}
