using UnityEngine;

namespace SRS.Combat
{
	public interface IOnHitEffect
	{
		public void Trigger(GameObject target);
	}
}