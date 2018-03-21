#pragma once

#include <pcl/filters/boost.h>
#include <pcl/filters/filter.h>
#include <map>
#include <unordered_map>

using namespace Eigen;
using namespace std;

namespace std {

	template <>
	struct hash<Eigen::Vector2i>
	{
		std::size_t operator()(const Eigen::Vector2i& k) const
		{
			using std::size_t;
			using std::hash;
			using std::string;

			// Compute individual hash values for first,
			// second and third and combine them using XOR
			// and bit shifting:

			return ((hash<int>()(k[0])
				^ (hash<int>()(k[1]) << 1)) >> 1);
		}
	};
}

namespace pcl
{
	namespace filters
	{
		struct CmpVector2i
		{
			bool operator() (const Vector2i& lhs, const Vector2i& rhs) const
			{
				return lhs[0] < rhs[0] && lhs[1] < rhs[1];
			}
		};

		struct MPoint
		{
			float height;
			int idx;

			MPoint()
			{
				height = 0;
				idx = 0;
			}

			MPoint(const float height, const int idx)
			{
				this->height = height;
				this->idx = idx;
			}
		};

		struct CmpMPointDesc
		{
			bool operator() (const MPoint& lhs, const MPoint& rhs) const
			{
				return lhs.height > rhs.height;
			}
		};

		template <typename PointT> 
		class HeightMap2D : public PCLBase<PointT>
		{

		public:
			typedef pcl::PointCloud<PointT> PointCloud;
			typedef boost::shared_ptr<PointCloud> PointCloudPtr;
			typedef boost::shared_ptr<const PointCloud> PointCloudConstPtr;

			HeightMap2D() :
				buckets_(),
				max_buckets_(),
				maxima_cloud_indices_filtered_(),
				min_dist_between_maxima_(0.3),
				bin_size_(0.06)
			{
			}

			inline
			void setGroundCoeffs(const Eigen::VectorXf &ground_coeffs)
			{
				if (ground_coeffs.size() != 4)
				{
					PCL_ERROR("incorrect ground coefficients size");
				}

				ground_coeffs_ = ground_coeffs;
			}

			inline
			void setMinDistBetweenMaxima(const float &dist)
			{
				min_dist_between_maxima_ = dist;
			}

			inline
			float getMinDistBetweenMaxima()
			{
				return min_dist_between_maxima_;
			}

			inline 
			float getBinSize()
			{
				return bin_size_;
			}

			inline
			void setBinSize(const float &value)
			{
				bin_size_ = value;
			}

			inline
			int getMaximaNumberAfterFiltering()
			{
				return maxima_number_after_filtering_;
			}

			inline
			Vector3f Project(const Vector3f &v, const Vector3f &normal) const
			{
				return v - v.dot(normal) * normal;
			}

			inline
			vector<int>& getMaximaCloudIndicesFiltered()
			{
				return maxima_cloud_indices_filtered_;
			}

			void searchLocalMaxima()
			{
				maxima_number_ = 0;
				max_buckets_.resize(buckets_.size());

				for (auto const& it : buckets_)
				{
					for (int dx = -1; dx < 2; dx++)
						for(int dy = -1; dy < 2; dy++)
						{
							auto key = it.first + Vector2i(dx, dy);
							auto search = buckets_.find(key);
							if (search == buckets_.end())
								continue;
							if (search->second.height > it.second.height)
								goto nextKvp;
						}

					max_buckets_[maxima_number_++] = it.second;

					nextKvp:;
				}

				max_buckets_.resize(maxima_number_);

				sort(max_buckets_.begin(), max_buckets_.end(), CmpMPointDesc());
			}

			void filterMaxima()
			{
				Vector3f normal = ground_coeffs_.head(3);
				float pow_sqrt_ground_coeffs_ = normal.squaredNorm();
				float pow_min_dist_between_maxima_ = pow(min_dist_between_maxima_, 2);

				maxima_number_after_filtering_ = 0;
				maxima_cloud_indices_filtered_.resize(maxima_number_, 0);
				if (maxima_number_ > 0)
				{
					for (int i = 0; i < maxima_number_; i++)
					{
						bool good_maximum = true;

						Vector3f max_p = input_->points[max_buckets_[i].idx].getVector3fMap();
						float t = max_p.dot(normal) + ground_coeffs_[3];
						max_p -= normal * t; //max_p is projected onto the ground plane.

						for (int j = i - 1; j >= 0 && good_maximum; j--)
						{
							Vector3f previous_max_p = input_->points[max_buckets_[j].idx].getVector3fMap();
							t = previous_max_p.dot(normal) + ground_coeffs_[3];
							previous_max_p -= normal * t;

							float distance = (max_p - previous_max_p).squaredNorm();
							if(distance < pow_min_dist_between_maxima_)
							{
								good_maximum = false;
							}
						}
						if (good_maximum)
						{
							maxima_cloud_indices_filtered_[maxima_number_after_filtering_] = max_buckets_[i].idx;
							maxima_number_after_filtering_++;
						}
					}
				}
			}

			void filter()
			{
				buckets_.clear();
				buckets_.reserve(indices_->size());

				//Vector2i bmin_(INT_MAX, INT_MAX);
				//Vector2i bmax_(-INT_MAX, -INT_MAX);

				max_buckets_.clear();
				maxima_cloud_indices_filtered_.clear();

				Vector3f normal = ground_coeffs_.head(3);
				Vector3f pxa = Project(Vector3f(1, 0, 0), normal);
				pxa.normalize();
				Vector3f pya = normal.cross(pxa);

				for (auto it = indices_->begin(); it < indices_->end(); it++)
				{
					Vector3f p = input_->operator[](*it).getVector3fMap();

					auto pp = Vector2f(p.dot(pxa), p.dot(pya));
					int iix = pp[0] / bin_size_;
					int iiy = pp[1] / bin_size_;
					auto index = Vector2i(iix, iiy);
					//bmin_ = bmin_.cwiseMin(index);
					//bmax_ = bmax_.cwiseMax(index);

					// compute point height from the groundplane
					float heightp = p.dot(normal) + ground_coeffs_(3);

					auto search = buckets_.find(index);
					if (search == buckets_.end())
					{
						buckets_[index] = MPoint(heightp, *it);
					}
					else
					{
						if (heightp > search->second.height)
						{
							search->second.height = heightp;
							search->second.idx = *it;
						}
					}
				}

				// Compute local maxima of the height map:
				searchLocalMaxima();

				// Filter maxima by imposing a minimum distance between them (minimum distance between people heads):
				filterMaxima();
			}

		protected:

			Eigen::VectorXf ground_coeffs_;
			
			std::unordered_map<Eigen::Vector2i, MPoint> buckets_;

			std::vector<MPoint> max_buckets_;
			std::vector<int> maxima_cloud_indices_filtered_;

			float min_dist_between_maxima_;
			float bin_size_;

			int maxima_number_;
			int maxima_number_after_filtering_;
		};
	}
}