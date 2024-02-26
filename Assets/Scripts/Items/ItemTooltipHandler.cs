using System.Text;
using UnityEngine;
using SRS.Stats;
using SRS.UI;

namespace SRS.Items
{
	public class ItemTooltipHandler : MonoBehaviour
	{
		[SerializeField] private TooltipContainer container;
		[SerializeField] private StatContainer playerStats;

		private void ShowStats(Item item, Vector3 position)
		{
			StringBuilder descriptionBuilder = new();
			
			foreach(string stat in item.AffectedStats)
			{
				descriptionBuilder.AppendLine(StatFormatter.GetStat(playerStats[stat]));
			}
			
			container.gameObject.SetActive(true);

			container.Draw(descriptionBuilder.ToString(), position);
		}

		private void DisableTooltip()
		{
			container.gameObject.SetActive(false);
		}
	}
}