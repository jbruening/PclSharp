using System;
using System.Diagnostics;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PclSharp.Common;
using PclSharp.Filters;
using PclSharp.IO;
using PclSharp.SampleConsensus;
using PclSharp.Segmentation;
using PclSharp.Std;
using static PclSharp.Test.TestData;

namespace PclSharp.Test
{
    [TestClass]
    public class PlanarSegmentation
    {
        private Random _r = new Random();

        //http://pointclouds.org/documentation/tutorials/planar_segmentation.php#planar-segmentation
        [TestMethod]
        public unsafe void PlanarSegmentationTutorialTest()
        {
            using (var cloud = new PointCloudOfXYZ())
            {
                cloud.Width = 15;
                cloud.Height = 1;
                cloud.Points.Resize(cloud.Width * cloud.Height);

                for(var i = 0; i < cloud.Points.Count; i++)
                {
                    (cloud.Data + i)->X = 1024 * rand();
                    (cloud.Data + i)->Y = 1024 * rand();
                    (cloud.Data + i)->Z = 1;
                }

                //set a few outliers
                (cloud.Data + 0)->Z = 2f;
                (cloud.Data + 3)->Z = -2f;
                (cloud.Data + 6)->Z = 4f;

                using (var seg = new SACSegmentationOfXYZ())
                using (var inliers = new PointIndices())
                using (var coefficients = new ModelCoefficients())
                {
                    seg.OptimizeCoefficients = true;
                    seg.ModelType = SACModel.Plane;
                    seg.MethodType = SACMethod.RANSAC;
                    seg.DistanceThreshold = 0.01;

                    seg.SetInputCloud(cloud);
                    seg.Segment(inliers, coefficients);

                    if (inliers.Indices.Count == 0)
                        Assert.Fail("Could not estimate a planar model for the given dataset");

                    Assert.AreEqual(4, coefficients.Values.Count);
                    Assert.AreEqual(0, coefficients.Values[0]);
                    Assert.AreEqual(0, coefficients.Values[1]);
                    Assert.AreEqual(1, coefficients.Values[2]);
                    Assert.AreEqual(-1, coefficients.Values[3]);

                    Console.WriteLine($"Model inliers: {inliers.Indices.Count}");
                }
            }
        }

        private float rand()
            => (float) _r.NextDouble();
    }
}
