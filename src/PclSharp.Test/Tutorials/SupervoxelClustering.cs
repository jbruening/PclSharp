using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.Features;
using PclSharp.IO;
using PclSharp.Std;
using static PclSharp.Test.TestData;

namespace PclSharp.Test.Tutorials
{
    [TestClass]
    public class SupervoxelClustering
    {
        //http://pointclouds.org/documentation/tutorials/supervoxel_clustering.php#supervoxel-clustering
        [TestMethod]
        public unsafe void SupervoxelClusteringTutorialTest()
        {
            var voxelResolution = 0.008f;
            var seedResolution = 0.1f;
            var colorImportance = 0.2f;
            var spatialImportance = 0.4f;
            var normalImportance = 1f;

            using (var cloud = new PointCloudOfXYZRGBA())
            using(var adjacentSupervoxelCenters = new PointCloudOfXYZRGBA())
            {
                using (var reader = new PCDReader())
                    //Assert.AreEqual(0, reader.Read(DataPath("tutorials/correspondence_grouping/milk_cartoon_all_small_clorox.pcd"), cloud));
                    Assert.AreEqual(0, reader.Read(DataPath("tutorials/table_scene_mug_stereo_textured.pcd"), cloud));

                var min = new Vector3(float.MaxValue);
                var max = new Vector3(float.MinValue);
                foreach (var p in cloud.Points)
                {
                    min = Vector3.Min(min, p.V);
                    max = Vector3.Max(max, p.V);
                }

                using (var normals = new PointCloudOfNormal(cloud.Width, cloud.Height))
                using (var super = new Segmentation.SupervoxelClusteringOfXYZRGBA(voxelResolution, seedResolution))
                using (var clusters = new Segmentation.SupervoxelClustersOfXYZRGBA())
                {
                    using (var ne = new IntegralImageNormalEstimationPointXYZAndNormal())
                    using (var noColor = new PointCloudOfXYZ(cloud.Width, cloud.Height))
                    {
                        var count = cloud.Count;
                        var cptr = cloud.Data;
                        var nptr = noColor.Data;
                        for (var i = 0; i < count; i++)
                            (nptr + i)->V = (cptr + i)->V;

                        ne.SetNormalEstimationMethod(IntegralImageNormalEstimation.NormalEstimationMethod.Average3DGradient);
                        ne.SetMaxDepthChangeFactor(0.02f);
                        ne.SetNormalSmoothingSize(10f);

                        ne.SetInputCloud(noColor);
                        ne.Compute(normals);
                    }

                    super.SetInputCloud(cloud);
                    super.SetNormalCloud(normals);

                    super.ColorImportance = colorImportance;
                    super.SpatialImportance = spatialImportance;
                    super.NormalImportance = normalImportance;

                    super.Extract(clusters);
                    Assert.IsTrue(clusters.Count > 0);

                    using (var adjacency = new MultiMapOfuintAnduint())
                    {
                        super.GetSupervoxelAdjacency(adjacency);
                        Assert.AreEqual(350, adjacency.Count);

                        var i = 0;
                        foreach (var kvp in adjacency)
                            i++;

                        Assert.AreEqual(350, i);

                        using (var labelItr = adjacency.Begin())
                        using (var end = adjacency.End())
                        {
                            for (; !labelItr.Equals(end);)
                            {
                                var supervoxelLabel = labelItr.Key;

                                var supervoxel = clusters.At(supervoxelLabel);

                                foreach (var kvp in adjacency.EqualRange(supervoxelLabel))
                                {
                                    var neighbor = clusters.At(kvp.Value);
                                    adjacentSupervoxelCenters.Add(neighbor.Centroid);
                                }

                                adjacency.UpperBound(supervoxelLabel, labelItr);
                            }
                        }

                        Assert.AreEqual(350, adjacentSupervoxelCenters.Count);
                    }
                }
            }
        }
    }
}
