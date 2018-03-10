using Microsoft.Kinect;
using PclSharp.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PclSharp.Kinect
{
    public static class Extensions
    {
        public static unsafe void Update(this DepthFrame depth, PointCloudOfXYZ cloud)
        {
            var fd = depth.FrameDescription;
            var sensor = depth.DepthFrameSource.KinectSensor;
            var pixels = fd.LengthInPixels;

            MatchSize(depth, cloud);

            var pPtr = cloud.Data;
            var pSize = (uint)Marshal.SizeOf<PointXYZ>() * pixels;

            using (var dBuffer = depth.LockImageBuffer())
                sensor.CoordinateMapper.MapDepthFrameToCameraSpaceUsingIntPtr(
                    dBuffer.UnderlyingBuffer, dBuffer.Size,
                    (IntPtr)pPtr, pSize);

            //we have the data copied raw, but it's misaligned, as kinect is 12 bytes/pixel. we need to 'expand' the data.
            //copying from the back will prevent data loss.
            var vptr = (Vector3*)pPtr;
            for(var i = pixels - 1; i >= 0; i--)
            {
                pPtr[i].V = vptr[i];
                pPtr[i].data[3] = 1; // just in case...
            }
        }

        public static unsafe void Update(this DepthFrame depth, uint* color, PointCloudOfXYZRGBA cloud)
        {
            var fd = depth.FrameDescription;
            var sensor = depth.DepthFrameSource.KinectSensor;
            var pixels = fd.LengthInPixels;
            MatchSize(depth, cloud);

            var pPtr = cloud.Data;
            var pSize = (uint)Marshal.SizeOf<PointXYZRGBA>() * pixels;

            using (var dBuffer = depth.LockImageBuffer())
                sensor.CoordinateMapper.MapDepthFrameToCameraSpaceUsingIntPtr(
                    dBuffer.UnderlyingBuffer, dBuffer.Size,
                    (IntPtr)pPtr, pSize);

            //we have the data copied raw, but it's misaligned, as kinect is 12 bytes/pixel. we need to 'expand' the data.
            //copying from the back will prevent data loss.
            var vptr = (Vector3*)pPtr;
            for (var i = pixels - 1; i >= 0; i--)
            {
                pPtr[i].V = vptr[i];
                pPtr[i].data[3] = 1;
                //also copy the color in the process.
                pPtr[i].RGBA = color[i];
            }
        }

        private static void MatchSize<PointT>(DepthFrame depth, PointCloud<PointT> cloud)
        {
            var fd = depth.FrameDescription;
            var sensor = depth.DepthFrameSource.KinectSensor;
            var pixels = fd.LengthInPixels;

            if (cloud.Width != fd.Width || cloud.Height != fd.Height || cloud.Count != pixels)
            {
                cloud.Points.Resize((int)fd.LengthInPixels);

                cloud.Width = fd.Width;
                cloud.Height = fd.Height;
                cloud.IsDense = false;
            }
        }
    }
}
