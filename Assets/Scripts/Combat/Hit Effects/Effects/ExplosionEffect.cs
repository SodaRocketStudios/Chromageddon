using SRS.Stats;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
    [CreateAssetMenu(fileName = "New Explosion Effect", menuName = "Combat/Hit Effects/Effects/Explosion Effect")]
    public class ExplosionEffect : Effect
    {
        [SerializeField] private float damage;

        public override void Apply(GameObject source, GameObject target)
        {
            float radius = source.GetComponent<StatContainer>()["Explosion Radius"].Value;

            Collider2D[] hits = Physics2D.OverlapCircleAll(target.transform.position, radius);

            foreach(Collider2D hit in hits)
            {
                hit.GetComponent<HitHandler>().Hit(damage, DamageType.Physical);
            }
        }
    }
}