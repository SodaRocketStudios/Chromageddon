using System.Collections.Generic;
using UnityEngine;

namespace SRS.EnemyManagement
{
	public class EnemyDatabase : MonoBehaviour
	{
		[SerializeField] private List<EnemyData> enemies;
		public List<EnemyData> Enemies
		{
			get => enemies;
		}
	}
}