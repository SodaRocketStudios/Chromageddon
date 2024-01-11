using UnityEngine;

namespace SRS.Stats
{
	public class EquipableObjectButton : MonoBehaviour
	{
		private StatContainer targetStats;
		public StatContainer TargetStats
		{
			set => targetStats = value;
		}

		private EquipableObject equipableObject;

		public void Select()
		{
			equipableObject.Equip(targetStats);
		}
	}
}