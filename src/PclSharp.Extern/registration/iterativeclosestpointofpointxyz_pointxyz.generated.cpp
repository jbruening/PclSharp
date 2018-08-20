#pragma once
#include "..\export.h"

#include <pcl/point_types.h>
#include <pcl/registration/icp.h>

using namespace pcl;
using namespace pcl::registration;
using namespace std;

typedef boost::shared_ptr<PointCloud<PointXYZ>> boost_src;
typedef boost::shared_ptr<PointCloud<PointXYZ>> boost_tgt;
typedef boost::shared_ptr<vector<int>> boost_indices;
typedef Eigen::Matrix<float, 4, 4> Matrix4;
typedef IterativeClosestPoint<PointXYZ, PointXYZ> classType;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(classType*) registration_icp_pointxyz_pointxyz_ctor()
{ return new classType(); }

EXPORT(void) registration_icp_pointxyz_pointxyz_delete(classType** ptr)
{
	delete *ptr;
	*ptr = NULL;
}

EXPORT(void) registration_icp_pointxyz_pointxyz_align(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, PointCloud<PointXYZ>* output)
{ ptr->align(*output); }
EXPORT(void) registration_icp_pointxyz_pointxyz_alignGuess(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, PointCloud<PointXYZ>* output, Matrix4* guess)
{ ptr->align(*output, *guess); }

EXPORT(void) registration_icp_pointxyz_pointxyz_setMaximumIterations(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, int value)
{ ptr->setMaximumIterations(value); }
EXPORT(int) registration_icp_pointxyz_pointxyz_getMaximumIterations(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return ptr->getMaximumIterations(); }
EXPORT(void) registration_icp_pointxyz_pointxyz_setUseReciprocalCorrespondences(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, int value)
{ ptr->setUseReciprocalCorrespondences(value); }
EXPORT(int) registration_icp_pointxyz_pointxyz_getUseReciprocalCorrespondences(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return ptr->getUseReciprocalCorrespondences(); }
EXPORT(void) registration_icp_pointxyz_pointxyz_setMaxCorrespondenceDistance(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, double value)
{ ptr->setMaxCorrespondenceDistance(value); }
EXPORT(double) registration_icp_pointxyz_pointxyz_getMaxCorrespondenceDistance(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return ptr->getMaxCorrespondenceDistance(); }
EXPORT(void) registration_icp_pointxyz_pointxyz_setRANSACOutlierRejectionThreshold(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, double value)
{ ptr->setRANSACOutlierRejectionThreshold(value); }
EXPORT(double) registration_icp_pointxyz_pointxyz_getRANSACOutlierRejectionThreshold(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return ptr->getRANSACOutlierRejectionThreshold(); }
EXPORT(void) registration_icp_pointxyz_pointxyz_setTransformationEpsilon(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, double value)
{ ptr->setTransformationEpsilon(value); }
EXPORT(double) registration_icp_pointxyz_pointxyz_getTransformationEpsilon(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return ptr->getTransformationEpsilon(); }
EXPORT(void) registration_icp_pointxyz_pointxyz_setEuclideanFitnessEpsilon(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, double value)
{ ptr->setEuclideanFitnessEpsilon(value); }
EXPORT(double) registration_icp_pointxyz_pointxyz_getEuclideanFitnessEpsilon(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return ptr->getEuclideanFitnessEpsilon(); }

EXPORT(void) registration_icp_pointxyz_pointxyz_setInputSource(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, PointCloud<PointXYZ>* cloud)
{ ptr->setInputSource(boost_src(boost_src(), cloud)); }

EXPORT(PointCloud<PointXYZ>*) registration_icp_pointxyz_pointxyz_getInputSource(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return boost::const_pointer_cast<PointCloud<PointXYZ>>(ptr->getInputSource()).get(); }


EXPORT(void) registration_icp_pointxyz_pointxyz_setInputTarget(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr, PointCloud<PointXYZ>* cloud)
{ ptr->setInputTarget(boost_tgt(boost_tgt(), cloud)); }

EXPORT(PointCloud<PointXYZ>*) registration_icp_pointxyz_pointxyz_getInputTarget(IterativeClosestPoint<PointXYZ, PointXYZ>* ptr)
{ return boost::const_pointer_cast<PointCloud<PointXYZ>>(ptr->getInputTarget()).get(); }

#ifdef __cplusplus  
}
#endif  
