using System;
using UnityEngine;

namespace SRS.Achievements
{
	public abstract class Condition : ScriptableObject
	{
		private bool isSatisfied;
		public bool IsSatisfied
		{
			get => isSatisfied;
		}

		public static Action<Condition> OnMet;
	}
}