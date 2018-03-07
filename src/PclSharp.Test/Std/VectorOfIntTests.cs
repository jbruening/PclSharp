using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.Std;

namespace PclSharp.Test.Std
{
    /// <summary>
    /// Summary description for VectorOfInt
    /// </summary>
    [TestClass]
    public class VectorOfIntTests
    {
        private VectorOfInt vector;

        public VectorOfIntTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestInitialize()
        {
            vector = new VectorOfInt();
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
         public void TestCleanup()
        {
            vector.Dispose();
        }
        //
        #endregion

        [TestMethod]
        public void TestCount()
        {
            Assert.AreEqual(0, vector.Count);
            vector.Add(1);
            vector.Add(2);
            Assert.AreEqual(2, vector.Count);
        }

        [TestMethod]
        public unsafe void TestData()
        {
            for (var i = 0; i < 10; i++)
                vector.Add(i);

            var ptr = (int*)vector.Data;
            for (var i = 0; i < 10; i++)
                Assert.AreEqual(i, ptr[i]);
        }
    }
}
