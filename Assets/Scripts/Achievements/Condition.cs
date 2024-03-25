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
				if(isSatisfied == value)
				{
					return;
				}

				isSatisfied = value;

				if(isSatisfied == true)
				{
					OnMet?.Invoke(this);
				}
			}
		}

		[SerializeField] protected ComparisonOperator comparison;
		
		[SerializeField] protected float targetValue;

		public static Action<Condition> OnMet;

		private bool initialized;

		public void Initialize()
		{
			if(initialized)
			{
				return;
			}
			
			isSatisfied = false;
			Init();

			initialized = true;
		}

		public void Test(float value)
		{
			switch(comparison)
			{
				case ComparisonOperator.Less:

					if(value < targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.LessOrEqual:
								
					if(value <= targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.Equal:
								
					if(value == targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.GreaterOrEqual:
								
					if(value >= targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
				case ComparisonOperator.Greater:
								
					if(value > targetValue)
					{
						IsSatisfied = true;
						break;
					}

					IsSatisfied = false;

					break;
			}
		}
		
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