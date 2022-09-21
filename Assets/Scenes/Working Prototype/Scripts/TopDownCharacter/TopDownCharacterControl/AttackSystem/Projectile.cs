using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public class Projectile : MonoBehaviour
	{
		private Dictionary<string, Stat> attackStats = new Dictionary<string, Stat>();

		public void SetStats(Dictionary<string, Stat> stats)
		{
			attackStats = new Dictionary<string, Stat>(stats);
		}
	}
}