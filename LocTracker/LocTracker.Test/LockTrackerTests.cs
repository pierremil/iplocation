using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace LocTracker.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AssertImagesExist()
        {
            var exit = LocTracker.Properties.Resources.Exit;
            Assert.IsInstanceOfType(exit, typeof(Bitmap));
                        
            
        }
    }
}
