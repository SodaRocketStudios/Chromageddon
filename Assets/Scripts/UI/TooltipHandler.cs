using UnityEngine;

namespace SRS.UI
{
	public class TooltipHandler : MonoBehaviour
	{
		[SerializeField] private TooltipContainer tooltipContainer;

		private void OnEnable()
		{
			TMPTextLinkHoverHandler.OnPointerEnter += DrawTooltip;
			TMPTextLinkHoverHandler.OnPointerExit += RemoveTooltip;
		}

		private void OnDisable()
		{
			TMPTextLinkHoverHandler.OnPointerEnter -= DrawTooltip;
			TMPTextLinkHoverHandler.OnPointerExit -= RemoveTooltip;
		}

		public void DrawTooltip(string keyword, Vector3 position)
		{
			tooltipContainer.gameObject.SetActive(true);
		}

		public void RemoveTooltip()
		{
			tooltipContainer.gameObject.SetActive(false);
		}
	}
}