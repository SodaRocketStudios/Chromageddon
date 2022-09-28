using UnityEngine;

namespace SRS.StatusEffects
{
	public class TestAffectApplicator : MonoBehaviour
	{
		public void ApplyPoisonToPlayer(StatusEffectTracker tracker)
		{
			tracker.ApplyEffect<TestPoisonEffect>();
		}
	}
}