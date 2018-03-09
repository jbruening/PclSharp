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
                    using(var cloudPlane = new PointCloudOfXYZ())
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
                        }
                    }
                }
            }
        }
    }
}
