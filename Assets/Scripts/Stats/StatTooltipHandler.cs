using UnityEngine;
using SRS.UI;

namespace SRS.Stats
{
	public class StatTooltipHandler : MonoBehaviour
	{
		[SerializeField] private TooltipContainer container;
		[SerializeField] private StatContainer playerStats;

		private void OnEnable()
		{
			TMPTextLinkHoverHandler.OnPointerEnter += ShowStat;
			TMPTextLinkHoverHandler.OnPointerExit += DisableTooltip;
		}

		private void OnDisable()
		{
			TMPTextLinkHoverHandler.OnPointerEnter -= ShowStat;
			TMPTextLinkHoverHandler.OnPointerExit -= DisableTooltip;
		}

		private void ShowStat(string stat, Vector3 position)
		{
			container.gameObject.SetActive(true);

			container.Draw(StatFormatter.GetStat(playerStats[stat]), position);
		}

		private void DisableTooltip()
		{
			container.gameObject.SetActive(false);
		}
	}
}