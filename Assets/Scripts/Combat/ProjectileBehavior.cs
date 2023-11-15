using UnityEngine;

namespace SRS.Combat
{
    public class ProjectileBehavior : AttackBehavior
    {
        [SerializeField] private float speed = 1;

        private void Update()
        {
            transform.Translate(transform.right*speed*Time.deltaTime, Space.World);
        }

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
