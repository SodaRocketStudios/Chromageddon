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
			// TODO -- make different buttons for the different types of equipable objects.
			// weapons need to apply to attack manager, while items go into inventory, so they act differently.
			equipableObject.Equip(targetStats);
		}
	}
}