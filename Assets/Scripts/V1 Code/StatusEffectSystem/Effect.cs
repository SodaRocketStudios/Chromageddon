using UnityEngine;

namespace SRS.StatusEffects
{
    public abstract class Effect : ScriptableObject
    {
        public abstract void Apply(GameObject target);

        public abstract void Remove();

        public virtual void Update()
        {}
    }
}
