using System;
using UnityEngine;

namespace SRS.Achievements
{
	public abstract class Condition : ScriptableObject
	{
		private bool isSatisfied = false;
		public bool IsSatisfied
		{
			get => isSatisfied;
			set
			{
				Debug.Log($"Satisfied: {value}, {isSatisfied}");
				if(isSatisfied == value)
				{
					return;
				}

				isSatisfied = value;

				if(isSatisfied == true)
				{
					Debug.Log("Condition Met");
					OnMet?.Invoke(this);
				}
			}
		}

		[SerializeField] protected ComparisonOperator comparison;
		
		[SerializeField] protected float targetValue;

		public static Action<Condition> OnMet;

		public void Initialize()
		{
			isSatisfied = false;
			Init();
		}

		public abstract void Test(float value);
		
		protected abstract void Init();
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