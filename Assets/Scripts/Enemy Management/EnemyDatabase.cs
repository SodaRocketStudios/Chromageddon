using System.Collections.Generic;
using UnityEngine;

namespace SRS.EnemyManagement
{
	[CreateAssetMenu(fileName = "New Enemy Database", menuName = "Enemies/Enemy Database")]
	public class EnemyDatabase : ScriptableObject
	{
		[SerializeField] private List<EnemyData> enemies;
		public List<EnemyData> Enemies
		{
			get => enemies;
		}
	}
}