using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.IO;
using static PclSharp.Test.TestData;
using PclSharp.Features;

namespace PclSharp.Test.Features
{
    /// <summary>
    /// Summary description for IntegralImageTests
    /// </summary>
    [TestClass]
    public class IntegralImageTests
    {
        public IntegralImageTests()
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
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestIntegralFile()
        {
            //copying integral image tutorial from http://pointclouds.org/documentation/tutorials/normal_estimation_using_integral_images.php#normal-estimation-using-integral-images
            using (var cloud = new PointCloudOfXYZ())
            using (var normals = new PointCloudOfNormal())
            using(var ne = new IntegralImageNormalEstimationPointXYZAndNormal())
            {
                using (var reader = new PCDReader())
                    if (reader.Read(DataPath("tutorials/table_scene_mug_stereo_textured.pcd"), cloud) < 0)
                        Assert.Fail("could not open pcd file");

                ne.SetNormalEstimationMethod(IntegralImageNormalEstimation.NormalEstimationMethod.Average3DGradient);
                ne.SetMaxDepthChangeFactor(0.02f);
                ne.SetNormalSmoothingSize(10f);
                ne.SetInputCloud(cloud);
                ne.Compute(normals);

                Assert.IsTrue(normals.Count == cloud.Count, "normals count did not match cloud count");
            }
        }
    }
}
