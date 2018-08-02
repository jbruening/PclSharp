#pragma once
#include "export.h"

#include "pcl\point_types.h"

using namespace pcl;

#ifdef __cplusplus
extern "C" {
#endif 

EXPORT(int*) GetSizes(int* count)
{
	int sz[]
	{
		sizeof(PointXYZ),
		sizeof(PointXYZRGBA),
		sizeof(Normal),
		sizeof(PointNormal),
		sizeof(PointXYZL),
	};

	*count = sizeof(sz) / sizeof(*sz);

	//now that we have our variables, copy the data out.
	int* ret = new int[*count];
	memcpy(ret, sz, sizeof(sz));

	return ret;
}

#ifdef __cplusplus  
}
#endif