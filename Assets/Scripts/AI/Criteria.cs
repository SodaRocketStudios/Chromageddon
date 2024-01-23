using UnityEngine;

namespace SRS.AI
{
	public abstract class Criteria : ScriptableObject
	{
		public abstract bool Check(AIBrain brain);
	}
}