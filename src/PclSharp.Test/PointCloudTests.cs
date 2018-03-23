using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using PclSharp.Struct;
using System.Runtime.InteropServices;
using static PclSharp.Test.TestData;
using PclSharp.IO;

namespace PclSharp.Test
{
    /// <summary>
    /// Summary description for PointCloudTest
    /// </summary>
    [TestClass]
    public class PointCloudTests
    {
        private PointCloudOfXYZ cloud;

        public PointCloudTests()
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
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestInitialize()
        {
            cloud = new PointCloudOfXYZ();
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestCleanup()
        {
            cloud.Dispose();
        }
        //
        #endregion

        [TestMethod]
        public unsafe void TestAdd()
        {
            Assert.AreEqual(16, sizeof(PointXYZ));
            Assert.AreEqual(16, Marshal.SizeOf<PointXYZ>());

            cloud.Add(new Vector3(1, 2, 3));

            Assert.AreEqual(1, cloud.Count);
        }

        [TestMethod]
        public void TestOrganized()
        {
            for (var i = 0; i < 10; i++)
                cloud.Add(new Vector3(i, i, i));

            Assert.IsFalse(cloud.IsOrganized);
            Assert.AreEqual(10, cloud.Width);

            cloud.Width = 5;
            cloud.Height = 2;
            Assert.IsTrue(cloud.IsOrganized);

            Assert.AreEqual(6f, cloud.At(1, 1).X);
        }

        [TestMethod]
        public unsafe void TestData()
        {
            for (var i = 0; i < 10; i++)
                cloud.Add(new Vector3(i, i, i));

            var ptr = cloud.Data;

            for (var i = 0; i < 10; i++)
                Assert.AreEqual(i, ptr[i].X);
        }

        [TestMethod]
        public unsafe void TestCtorWH()
        {
            using (var cloud = new PointCloudOfXYZ(10, 10))
            {
                ref PointXYZ foo = ref cloud.At(5, 5);

                foo.X = 5;

                var ptr = cloud.Data;
                Assert.AreEqual(5, ptr[55].X);
            }
        }

        [TestMethod]
        public void TestDownsample()
        {
            using (var reader = new PCDReader())
                reader.Read(DataPath("tutorials/table_scene_mug_stereo_textured.pcd"), cloud);

            using (var down = new PointCloudOfXYZ())
            {
                cloud.Downsample(2, down);

                Assert.AreEqual(320, down.Width);
                Assert.AreEqual(240, down.Height);
            }
        }
    }
}
