using UnityEngine;

namespace SRS.AI
{
	public abstract class Action : ScriptableObject
	{
		public abstract void Execute(AIBrain brain);
	}
}