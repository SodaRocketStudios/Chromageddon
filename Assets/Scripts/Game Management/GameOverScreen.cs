using UnityEngine;

namespace SRS.GameManagement
{
	public class GameOverScreen : MonoBehaviour
	{
		[SerializeField] private GameObject gameOverScreen;

		private void Start()
		{
			Game.Instance.OnGameOver += SetGameOver;
		}

		public void SetGameOver()
		{
			gameOverScreen.SetActive(true);
		}
	}
}