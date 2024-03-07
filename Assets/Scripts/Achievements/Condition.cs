using System;
using UnityEngine;

namespace SRS.Achievements
{
	public abstract class Condition : ScriptableObject
	{
		[SerializeField] private new string name;
		public string Name
		{
			get => name;
		}

		private bool isSatisfied;
		public bool IsSatisfied
		{
			get => isSatisfied;
		}

		public static Action<Condition> OnMet;
	}
}