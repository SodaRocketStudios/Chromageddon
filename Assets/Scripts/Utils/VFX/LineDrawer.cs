using SRS.Utils.ObjectPooling;
using UnityEngine;

namespace SRS.Utils.VFX
{
	public class LineDrawer : PooledObject
	{
		LineRenderer lineRenderer;

		private void Awake()
		{
			lineRenderer = GetComponent<LineRenderer>();
		}

		public void Initialize(Vector3 start, Vector3 end, float lifetime)
		{
			lineRenderer.SetPosition(0, start);
			lineRenderer.SetPosition(1, end);

			Invoke("ReturnToPool", lifetime);
		}
	}
}