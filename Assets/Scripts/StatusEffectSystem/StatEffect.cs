using UnityEngine;
using SRS.StatSystem;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Stat Effect", menuName = "StatusEffect/Stat Effect")]
	public class StatEffect : ScriptableObject
	{
		[SerializeField] private string stat;
		public string Stat {get {return stat;}}

		[SerializeField] private StatModifier modifier;
		public StatModifier Modifier {get {return modifier;}}
	}
}