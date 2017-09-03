using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using os.FileParser.Api.Models;

namespace os.FileParser.Test
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void AddressNullShouldThrowExepton()
        {
            Address address = null;

            address.StreetName = "Test Name";
            address.StreetNumber = "100";
            address.ZipCode = "1123";

            Assert.AreEqual("Test Name", address.StreetName);
        }
    }
}
