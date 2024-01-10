using UnityEngine;

namespace SRS.Progression
{
	public class Experience : MonoBehaviour
	{
		private int value;

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
				// TODO -- despawn XP.
			}
		}
	}
}