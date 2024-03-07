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
			set
			{
				if(isSatisfied == value)
				{
					return;
				}

				if(value == true)
				{
					OnMet?.Invoke(this);
				}
				
				isSatisfied = value;
			}
		}

		[SerializeField] protected ComparisonOperator comparison;
		
		[SerializeField] protected float targetValue;

		public static Action<Condition> OnMet;

		public abstract void Initialize();

		public abstract void Test(float value);
	}

	public enum ComparisonOperator
	{
		Less,
		LessOrEqual,
		Equal,
		GreaterOrEqual,
		Greater
	}
}