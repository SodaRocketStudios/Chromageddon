using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

namespace SRS.Utils
{
	public class TMPTextLinkHoverHandler : MonoBehaviour
	{
		private TMP_Text textBox;
		private RectTransform textBoxTransform;
		private Camera mainCamera;

		private int activeElement = -1;

		public delegate void OnPointerEnterEvent(string keyword, Vector3 mousePosition);
		public static event OnPointerEnterEvent OnPointerEnter;

		public static Action OnPointerExit;

		private void Awake()
		{
			textBox = GetComponent<TMP_Text>();
			textBoxTransform = GetComponent<RectTransform>();

			mainCamera = Camera.main;
		}

		private void Update()
		{
			CheckForLinkAtMousePosition();
		}

		private void OnDisable()
		{
			activeElement = -1;
		}

		private void CheckForLinkAtMousePosition()
		{
			Vector3 mousePosition = Mouse.current.position.ReadValue();

			if(!TMP_TextUtilities.IsIntersectingRectTransform(textBoxTransform, mousePosition, mainCamera))
			{
				if(activeElement < 0)
				{
					return;
				}

				activeElement = -1;
				OnPointerExit?.Invoke();
				return;
			}

			int intersectingLink = TMP_TextUtilities.FindIntersectingLink(textBox, mousePosition, mainCamera);

			if(intersectingLink != activeElement && activeElement >= 0)
			{
				OnPointerExit?.Invoke();
			}

			activeElement = intersectingLink;
			
			if(intersectingLink < 0)
			{
				return;
			}

			TMP_LinkInfo linkInfo = textBox.textInfo.linkInfo[intersectingLink];

			OnPointerEnter?.Invoke(linkInfo.GetLinkID(), mainCamera.ScreenToWorldPoint(mousePosition));
		}
	}
}