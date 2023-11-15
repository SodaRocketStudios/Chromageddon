using UnityEngine;

namespace SRS.Combat
{
    public class MeleeBehavior : AttackBehavior
    {
        protected override void OnStatsSet()
        {
			lifetime = 0.1f;
            throw new System.NotImplementedException();
        }

        protected override void HitBehavior(GameObject other)
        {
            throw new System.NotImplementedException();
        }

    }
}
