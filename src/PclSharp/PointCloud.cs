using System;
using System.Collections.Generic;

namespace PclSharp
{
    public abstract class PointCloud<PointT> : UnmanagedObject
    {
        public abstract PointT At(int col, int row);
        public abstract void Add(PointT value);
    }
}
