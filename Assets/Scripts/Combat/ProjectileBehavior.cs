using UnityEngine;

namespace SRS.Combat
{
    public class ProjectileBehavior : AttackBehavior
    {
        protected override void OnStatsSet()
        {
			lifetime = stats["Range"].Value;
        }

        protected override void HitBehavior(GameObject other)
        {
			// TODO handle bounces and pierces
            throw new System.NotImplementedException();
        }

    }
}
