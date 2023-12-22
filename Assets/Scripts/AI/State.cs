using System.Collections.Generic;
using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(menuName = "Enemies/AI/State", fileName = "New State")]
	public class State : ScriptableObject
	{
		[SerializeField] private List<Action> actions = new();
		[SerializeField] private List<Transition> transitions = new();

		public void Execute(AIBrain brain)
		{
			foreach(Action action in actions)
			{
				action.Execute(brain);
			}

			foreach(Transition transition in transitions)
			{
				transition.Test(brain);
			}
		}
	}
}