using System;
using System.Runtime.InteropServices;
using PclSharp.Struct;
using PclSharp.Std;

namespace PclSharp.Search
{
	public static partial class Invoke
	{
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern IntPtr search_organizedNeighbor_xyz_ctor(bool sorted, float eps, uint pyramidLevel);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void search_organizedNeighbor_xyz_delete(ref IntPtr ptr);

		//methods
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void search_organizedNeighbor_xyz_setInputCloud(IntPtr ptr, IntPtr cloud);

		//properties
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern void search_organizedNeighbor_xyz_setSortedResults(IntPtr ptr, bool value);
		[DllImport(Native.DllName, CallingConvention=Native.CallingConvention)]
		public static extern bool search_organizedNeighbor_xyz_getSortedResults(IntPtr ptr);
	}

    public class OrganizedNeighborOfXYZ : OrganizedNeighbor<PointXYZ>
    {
		public override bool SortedResults
		{
			get { return Invoke.search_organizedNeighbor_xyz_getSortedResults(_ptr); }
            set { Invoke.search_organizedNeighbor_xyz_setSortedResults(_ptr, value); }
		}

		public OrganizedNeighborOfXYZ(bool sorted = false, float eps = 1e-4f, uint pyramidLevel = 5)
		{
			_ptr = Invoke.search_organizedNeighbor_xyz_ctor(sorted, eps, pyramidLevel);
		}

        public override void SetInputCloud(PointCloud<PointXYZ> cloud)
		{
			Invoke.search_organizedNeighbor_xyz_setInputCloud(_ptr, cloud);
		}

		protected override void DisposeObject()
		{
			Invoke.search_organizedNeighbor_xyz_delete(ref _ptr);
		}
    }
}
