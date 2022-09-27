using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class StatusEffectFactory : ScriptableObject
	{
		public abstract StatusEffectBehavior GetStatusEffect();
	}

	public class StatusEffectFactory<effectType> : StatusEffectFactory
	where effectType : StatusEffectBehavior, new()
	{
		public override StatusEffectBehavior GetStatusEffect()
		{
			return new effectType();
		}
    }
}