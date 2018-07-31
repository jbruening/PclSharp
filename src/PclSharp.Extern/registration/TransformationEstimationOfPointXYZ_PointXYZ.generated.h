#pragma once
#include "..\export.h"

#include <pcl/point_types.h>
#include <pcl/registration/transformation_estimation.h>

using namespace pcl;
using namespace std;

typedef boost::shared_ptr<PointCloud<PointXYZ>> boost_src;
typedef boost::shared_ptr<vector<int>> boost_indices;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(TransformationEstimation<PointXYZ, PointXYZ>*) registration_transformationEstimation_pointxyz_pointxyz_ctor()
{ return new TransformationEstimation<PointXYZ, PointXYZ>(); }

EXPORT(void) registration_transformationEstimation_pointxyz_pointxyz_delete(TransformationEstimation<PointXYZ, PointXYZ>** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) registration_transformationEstimation_pointxyz_pointxyz_estimateRigidTransformation(TransformationEstimation<PointXYZ, PointXYZ>* ptr, PointCloud<PointXYZ>* cloud_src, PointCloud<PointXYZ>* cloud_tgt, Matrix4* transformation_matrix)
{ ptr->estimateRigidTransformation(*cloud_src, *cloud_tgt, *transformation_matrix); }

#ifdef __cplusplus  
}
#endif  
