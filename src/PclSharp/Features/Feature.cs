using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclSharp.Features
{
    public abstract class Feature<PointInT, PointOutT> : UnmanagedObject
    {
        public abstract void Compute(PointCloud<PointOutT> cloud);
    }
}
