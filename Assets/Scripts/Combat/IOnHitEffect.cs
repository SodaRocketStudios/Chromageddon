using UnityEngine;

namespace SRS.Combat
{
	public interface IOnHitEffect
	{
		public string ProcStat{get;}

		public void Trigger(GameObject target);
	}
}