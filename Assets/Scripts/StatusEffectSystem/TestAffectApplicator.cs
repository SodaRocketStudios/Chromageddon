using UnityEngine;
using SRS.Stats;

namespace SRS.StatusEffects
{
	public class TestAffectApplicator : MonoBehaviour
	{
		public void ApplyPoisonToPlayer(GameObject target)
		{
			target.GetComponent<StatusEffectTracker>().TryApplyEffect<TestPoisonEffect>(target.GetComponent<CharacterData>().AttackStats);
		}
	}
}