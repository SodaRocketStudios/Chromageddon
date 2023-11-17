using SRS.Stats;

namespace SRS.Combat
{
	public interface IOnHitEffect
	{
		public void Trigger(StatContainer stats);
	}
}