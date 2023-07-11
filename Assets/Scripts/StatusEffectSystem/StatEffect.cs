using UnityEngine;
using SRS.StatSystem;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Stat Effect", menuName = "Status Effect/Stat Effect")]
	public class StatEffect : Effect
	{
		[SerializeField] private string stat;
		public string AffectedStat {get {return stat;}}

		[SerializeField] private StatModifier modifier;
		public StatModifier Modifier {get {return modifier;}}

		private CharacterStats targetStats;

        public override void Apply(GameObject target)
        {
			targetStats = target.GetComponent<CharacterStats>();
            
			targetStats.AddModifier(AffectedStat, modifier);
        }

        public override void Remove()
        {
			targetStats.RemoveModifier(AffectedStat, modifier);
        }
	}
}