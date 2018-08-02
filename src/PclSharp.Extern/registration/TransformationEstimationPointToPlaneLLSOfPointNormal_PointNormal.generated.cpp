#pragma once
#include "..\export.h"

#include <pcl/point_types.h>
#include <pcl/registration/transformation_estimation_point_to_plane_lls.h>

using namespace pcl;
using namespace pcl::registration;
using namespace std;

typedef boost::shared_ptr<PointCloud<PointNormal>> boost_src;
typedef boost::shared_ptr<vector<int>> boost_indices;
typedef Eigen::Matrix<float, 4, 4> Matrix4;
typedef TransformationEstimationPointToPlaneLLS<PointNormal, PointNormal> classType;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(classType*) registration_transformationEstimation_pointnormal_pointnormal_ctor()
{ return new classType(); }

EXPORT(void) registration_transformationEstimation_pointnormal_pointnormal_delete(classType** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) registration_transformationEstimation_pointnormal_pointnormal_estimateRigidTransformation(TransformationEstimationPointToPlaneLLS<PointNormal, PointNormal>* ptr, PointCloud<PointNormal>* cloud_src, PointCloud<PointNormal>* cloud_tgt, Matrix4* transformation_matrix)
{ ptr->estimateRigidTransformation(*cloud_src, *cloud_tgt, *transformation_matrix); }

#ifdef __cplusplus  
}
#endif  
