using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	public class AimGuide : MonoBehaviour
	{
		private LineRenderer lineRenderer;

		private StatContainer playerStats;

		private void Awake()
		{
			lineRenderer = GetComponent<LineRenderer>();

			playerStats = GetComponent<StatContainer>();

			lineRenderer.positionCount = 2;
		}

		private void Update()
		{
			lineRenderer.SetPosition(0, transform.position);
			lineRenderer.SetPosition(1, transform.right*playerStats["Range"].Value);
		}
	}
}