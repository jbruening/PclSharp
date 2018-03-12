#pragma once
#include "..\PclSharp.Extern\export.h"
#include <pcl/visualization/pcl_visualizer.h>

using namespace pcl;
using namespace std;
typedef pcl::visualization::PCLVisualizer visualizer;
typedef boost::shared_ptr<PointCloud<PointXYZ>> boost_xyz;
typedef boost::shared_ptr<PointCloud<PointXYZRGBA>> boost_xyzrgba;

#ifdef __cplusplus
extern "C" {
#endif

EXPORT(visualizer*) visualizer_ctor(const char* name, int create_interactor)
{ return new visualization::PCLVisualizer(string(name), create_interactor); }

EXPORT(void) visualizer_delete(visualizer** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) visualizer_setBackgroundColor(visualizer* ptr, unsigned char r, unsigned char g, unsigned char b)
{ ptr->setBackgroundColor(r, g, b); }

EXPORT(void) visualizer_addPointCloud_xyz(visualizer* ptr, PointCloud<PointXYZ>* cloud, const char* name, int viewport)
{ ptr->addPointCloud(boost_xyz(boost_xyz(), cloud), string(name), viewport); }

EXPORT(void) visualizer_addPointCloud_xyzrgba(visualizer* ptr, PointCloud<PointXYZRGBA>* cloud, const char* name, int viewport)
{ ptr->addPointCloud(boost_xyzrgba(boost_xyzrgba(), cloud), string(name), viewport); }

EXPORT(void) visualizer_setPointCloudRenderingProperties_1x(visualizer* ptr, int property, double value, const char* name, int viewport)
{ ptr->setPointCloudRenderingProperties(property, value, string(name), viewport); }

EXPORT(void) visualizer_spin(visualizer* ptr)
{ ptr->spin(); }

EXPORT(void) visualizer_spinOnce(visualizer* ptr, int time, bool forceRedraw)
{ ptr->spinOnce(time, forceRedraw); }

EXPORT(int) visualizer_contains(visualizer* ptr, const char* id)
{ return ptr->contains(string(id)); }

EXPORT(int) visualizer_wasStopped(visualizer* ptr)
{ return ptr->wasStopped(); }

#ifdef __cplusplus  
}
#endif
