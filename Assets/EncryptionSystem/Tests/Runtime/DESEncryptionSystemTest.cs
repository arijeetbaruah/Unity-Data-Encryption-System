using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Baruah.EncryptionSystem
{
    public class DESEncryptionSystemTest
    {
        [Test]
        public void DESEncryptionSystemTestSimplePasses()
        {
            new DESEncryptionSystem("ABCDEFGH");
            string val = "SomeThing";

            string result = DESEncryptionSystem.instance.EncryptAsString("SomeThing");

            string revert = DESEncryptionSystem.instance.DecryptAsString(result);
            Assert.True(Equals(revert, val));
        }
    }
}
