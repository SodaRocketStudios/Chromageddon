using UnityEngine;
using SRS.Stats;
using SRS.Utils.VFX;

namespace SRS.Combat.HitEffects
{
    [CreateAssetMenu(fileName = "New Explosion Effect", menuName = "Combat/Hit Effects/Effects/Explosion Effect")]
    public class ExplosionEffect : Effect
    {
        [SerializeField] private float damage;

        [SerializeField] private ParticleManager particleManager;

        public override void Apply(GameObject source, GameObject target)
        {
            float radius = source.GetComponent<StatContainer>()["Explosion Radius"].Value;

            ParticleSystem system = particleManager.PlayParticles(target.transform.position, Quaternion.identity);

            ParticleSystem.MainModule mainModule = system.main;
            mainModule.startSize = radius*2;

            Collider2D[] hits = Physics2D.OverlapCircleAll(target.transform.position, radius, LayerMask.GetMask(LayerMask.LayerToName(target.layer)));

            foreach(Collider2D hit in hits)
            {
                hit.GetComponent<HitHandler>()?.Hit(damage, DamageType.Physical);
            }
        }
    }
}