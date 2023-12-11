using UnityEngine;

namespace SRS.AI
{
	public abstract class Decision : ScriptableObject
	{
		public abstract bool Decide(AIBrain brain);
	}
}