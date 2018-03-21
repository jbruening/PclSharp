using PclSharp.Search;
using System;
using System.Collections.Generic;

namespace PclSharp.Surface
{
    public abstract class SurfaceBase<PointT> : PclBase<PointT>
    {
        public abstract void SetSearchMethod(Search<PointT> search);
        public abstract void Reconstruct(PolygonMesh output);
    }
}
