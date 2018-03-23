using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclSharp.Search
{
    public abstract class Search<PointT> : UnmanagedObject
    {
        public abstract bool SortedResults { get; set; }

        public abstract void SetInputCloud(PointCloud<PointT> cloud);
    }
}
