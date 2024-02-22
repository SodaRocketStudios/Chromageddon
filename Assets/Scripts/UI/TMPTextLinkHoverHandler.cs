using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

namespace SRS.UI
{
	public class TMPTextLinkHoverHandler : MonoBehaviour
	{
		private TMP_Text textBox;
		private RectTransform textBoxTransform;
		private Camera mainCamera;

		private int activeElement = -1;

		public delegate void OnPointerEnterEvent(string keyword, Vector3 mousePosition);
		public static event OnPointerEnterEvent OnPointerEnter;

		public Action OnPointerExit;

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

		private void CheckForLinkAtMousePosition()
		{
			Vector3 mousePosition = Mouse.current.position.ReadValue();

			if(!TMP_TextUtilities.IsIntersectingRectTransform(textBoxTransform, mousePosition, mainCamera))
			{
				activeElement = -1;
				return;
			}

			int intersectingLink = TMP_TextUtilities.FindIntersectingLink(textBox, mousePosition, mainCamera);

			if(intersectingLink != activeElement)
			{
				OnPointerExit?.Invoke();
				Debug.Log("Exit");
			}
			else
			{
				return;
			}

			activeElement = intersectingLink;
			
			if(intersectingLink < 0)
			{
				return;
			}

			TMP_LinkInfo linkInfo = textBox.textInfo.linkInfo[intersectingLink];

			OnPointerEnter?.Invoke(linkInfo.GetLinkID(), mousePosition);
			Debug.Log("Enter");

		}
	}
}