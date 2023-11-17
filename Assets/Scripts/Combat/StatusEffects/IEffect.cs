using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
	public interface IEffect
	{
		public void Apply(StatContainer targetStats);

		public void Remove(StatContainer targetStats);
	}
}
