using UnityEngine;

namespace SRS.Items
{
	public abstract class ItemBehavior : ScriptableObject
	{
		[SerializeField] private string description;
		
		public abstract void TryRun();
	}
}