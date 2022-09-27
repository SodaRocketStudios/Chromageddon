using UnityEngine;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Effect Data", menuName = "Status Effects/Effect Data")]
	public class EffectDataObject : ScriptableObject
	{
		public string Name;
		public float Intensity;

		public bool IsTicking;
		public float TickDelay;

		public bool ModifiesStat;
		public string AffectedStat;
		public ModifierType AffectedModifier;
	}

	public enum ModifierType
	{
		Additive,
		Multiplicative,
		Flat
	}
}