using UnityEngine;
using SRS.Utils.ObjectPooling;

namespace SRS.Progression
{
	public class Experience : PooledObject
	{
		private int value = 0;

		public void AddValue(int amount)
		{
			value += amount;
		}

		private void OnTriggerEnter(Collider other)
		{
			CharacterLevel level;

			if(other.TryGetComponent(out level))
			{
				level.AddXP(value);
				gameObject.SetActive(false);
			}
		}
	}
}