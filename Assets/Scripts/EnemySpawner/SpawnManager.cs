using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SRS
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> enemyTypes = new List<GameObject>();

		private IObjectPool<GameObject> enemyPool;
	}
}