namespace PclSharp.Registration
{
	public abstract class IterativeClosestPoint<PointSource, PointTarget> : Registration<PointSource, PointTarget>
	{
		public abstract bool UseReciprocalCorrespondences { get; set; }
	}
}
