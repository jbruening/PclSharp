#pragma once
#include "export.h"

#include "pcl\pcl_base.h"
#include "pcl\point_types.h"

using namespace pcl;
using namespace std;


#define POINT_CLOUD(type) \
EXPORT(PointCloud<##type##>*) pointcloud_##type##_ctor() \
{ \
	return new PointCloud<##type##>();\
} \
\
EXPORT(PointCloud<##type##>*) pointcloud_##type##_ctor_indices(PointCloud<##type##>* pc, vector<int>* indices) \
{ \
	return new PointCloud<##type##>(*pc, *indices);\
} \
\
EXPORT(type) pointcloud_##type##_at_colrow(PointCloud<##type##>* pc, int column, int row) { return pc->at(column, row); }\
\
EXPORT(void) pointcloud_##type##_delete(PointCloud<##type##>** ptr) \
{ \
	delete *ptr;\
	*ptr = NULL;\
} \

#ifdef __cplusplus  
extern "C" {  // only need to export C interface if  
			  // used by C++ source code  
#endif  

POINT_CLOUD(PointXYZ)
POINT_CLOUD(PointXYZRGB)

#ifdef __cplusplus  
}
#endif  