using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Baruah.EncryptionSystem
{
    public class AESEncryptionSystemTest
    {
        [Test]
        public void AESEncryptionSystemTestSimplePasses()
        {
            new AESEncryptionSystem("A60A5770FE5E7AB200BA9CFC94E4E8B0", "1234567887654321");
            string val = "SomeThing";

            string result = AESEncryptionSystem.instance.EncryptAsString("SomeThing");

            string revert = AESEncryptionSystem.instance.DecryptAsString(result);
            Assert.True(Equals(revert, val));
        }
    }
}
