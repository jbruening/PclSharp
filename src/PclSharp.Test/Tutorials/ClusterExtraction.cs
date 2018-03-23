using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.Filters;
using PclSharp.IO;
using PclSharp.SampleConsensus;
using PclSharp.Segmentation;
using PclSharp.Std;
using static PclSharp.Test.TestData;

namespace PclSharp.Test
{
    [TestClass]
    public class ClusterExtraction
    {
        //http://pointclouds.org/documentation/tutorials/cluster_extraction.php#cluster-extraction
        [TestMethod]
        public void ClusterExtractionTutorialTest()
        {
            using (var cloud = new PointCloudOfXYZ())
            using (var clusterIndices = new VectorOfPointIndices())
            {
                using (var reader = new PCDReader())
                    reader.Read(DataPath("tutorials/table_scene_lms400.pcd"), cloud);

                using (var vg = new VoxelGridOfXYZ())
                {
                    vg.SetInputCloud(cloud);
                    vg.LeafSize = new Vector3(0.01f);

                    var cloudFiltered = new PointCloudOfXYZ();
                    vg.filter(cloudFiltered);


                    using (var seg = new SACSegmentationOfXYZ()
                    {
                        OptimizeCoefficients = true,
                        ModelType = SACModel.Plane,
                        MethodType = SACMethod.RANSAC,
                        MaxIterations = 100,
                        DistanceThreshold = 0.02f
                    })
                    using (var cloudPlane = new PointCloudOfXYZ())
                    using (var coefficients = new Common.ModelCoefficients())
                    using (var inliers = new PointIndices())
                    {
                        int i = 0;
                        int nrPoints = cloudFiltered.Points.Count;

                        while (cloudFiltered.Points.Count > 0.3 * nrPoints)
                        {
                            seg.SetInputCloud(cloudFiltered);
                            seg.Segment(inliers, coefficients);
                            if (inliers.Indices.Count == 0)
                                Assert.Fail("could not estimate a planar model for the given dataset");

                            using (var extract = new ExtractIndicesOfXYZ() { Negative = false })
                            {
                                extract.SetInputCloud(cloudFiltered);
                                extract.SetIndices(inliers.Indices);

                                extract.filter(cloudPlane);

                                extract.Negative = true;
                                var cloudF = new PointCloudOfXYZ();
                                extract.filter(cloudF);

                                cloudFiltered.Dispose();
                                cloudFiltered = cloudF;
                            }

                            i++;
                        }

                        Assert.IsTrue(i > 1, "Didn't find more than 1 plane");
                        var tree = new Search.KdTreeOfXYZ();
                        tree.SetInputCloud(cloudFiltered);

                        using (var ec = new EuclideanClusterExtractionOfXYZ
                        {
                            ClusterTolerance = 0.02,
                            MinClusterSize = 100,
                            MaxClusterSize = 25000
                        })
                        {
                            ec.SetSearchMethod(tree);
                            ec.SetInputCloud(cloudFiltered);
                            ec.Extract(clusterIndices);
                        }

                        foreach(var pis in clusterIndices)
                        {
                            using (var cloudCluster = new PointCloudOfXYZ())
                            {
                                foreach(var pit in pis.Indices)
                                    cloudCluster.Add(cloudFiltered.Points[pit]);

                                cloudCluster.Width = cloudCluster.Points.Count;
                                cloudCluster.Height = 1;
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void OrganizedExtractionTest()
        {
            using (var cloud = new PointCloudOfXYZ())
            using (var clusterIndices = new VectorOfPointIndices())
            {
                using (var reader = new PCDReader())
                    reader.Read(DataPath("tutorials/table_scene_mug_stereo_textured.pcd"), cloud);
                int organizedClusterCount;

                using (var ec = new EuclideanClusterExtractionOfXYZ
                {
                    ClusterTolerance = 0.01,
                    MinClusterSize = 100,
                    MaxClusterSize = 800000
                })
                {
                    using (var organized = new Search.OrganizedNeighborOfXYZ())
                    using (var tree = new Search.KdTreeOfXYZ())
                    {
                        organized.SetInputCloud(cloud);

                        ec.SetSearchMethod(organized);
                        ec.Extract(clusterIndices);

                        organizedClusterCount = clusterIndices.Count;
                        clusterIndices.Clear();

                        ec.SetSearchMethod(tree);
                        ec.Extract(clusterIndices);

                        Assert.AreEqual(clusterIndices.Count, organizedClusterCount, "organized neighbor cluster count did not match kdtree cluster count");
                    }
                }
            }
        }
    }
}
