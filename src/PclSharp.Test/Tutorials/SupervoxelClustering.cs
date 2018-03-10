using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.IO;
using PclSharp.Std;
using static PclSharp.Test.TestData;

namespace PclSharp.Test.Tutorials
{
    [TestClass]
    public class SupervoxelClustering
    {
        //http://pointclouds.org/documentation/tutorials/statistical_outlier.php#statistical-outlier-removal
        [TestMethod]
        public void SupervoxelClusteringTutorialTest()
        {
            var voxelResolution = 0.008f;
            var seedResolution = 0.1f;
            var colorImportance = 0.2f;
            var spatialImportance = 0.4f;
            var normalImportance = 1f;

            using (var cloud = new PointCloudOfXYZRGBA())
            {
                using (var reader = new PCDReader())
                    Assert.AreEqual(0, reader.Read(DataPath("tutorials/correspondence_grouping/milk_cartoon_all_small_clorox.pcd"), cloud));

                using (var super = new Segmentation.SupervoxelClusteringOfXYZRGBA(voxelResolution, seedResolution))
                using (var clusters = new Segmentation.SupervoxelClustersOfXYZRGBA())
                {
                    super.Extract(clusters);
                    Assert.IsTrue(clusters.Count > 0);
                }
            }
        }
    }
}
