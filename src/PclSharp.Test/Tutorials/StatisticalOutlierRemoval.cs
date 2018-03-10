using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.IO;
using PclSharp.Std;
using static PclSharp.Test.TestData;

namespace PclSharp.Test.Tutorials
{
    [TestClass]
    public class StatisticalOutlierRemoval
    {
        //http://pointclouds.org/documentation/tutorials/statistical_outlier.php#statistical-outlier-removal
        [TestMethod]
        public void StatisticalOutlierRemovalTutorialTest()
        {
            using (var cloud = new PointCloudOfXYZ())
            using(var cloudFiltered = new PointCloudOfXYZ())
            {
                using (var reader = new PCDReader())
                    reader.Read(DataPath("tutorials/table_scene_lms400.pcd"), cloud);

                using (var sor = new Filters.StatisticalOutlierRemovalOfXYZ())
                {
                    sor.SetInputCloud(cloud);
                    sor.MeanK = 50;
                    sor.StdDevMulThresh = 1;
                    sor.filter(cloudFiltered);

                    Assert.IsTrue(cloudFiltered.Count > 0);
                    Assert.IsTrue(cloudFiltered.Count < cloud.Count);
                }
            }
        }
    }
}
