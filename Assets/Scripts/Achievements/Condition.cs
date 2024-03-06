using System;
using UnityEngine;

namespace SRS.Achievements
{
	public class Condition : ScriptableObject
	{
		public string Name;

		private bool isSatisfied;
		public bool IsSatisfied
		{
			get => isSatisfied;
		}

		public Action<Condition> OnMet;
	}
}