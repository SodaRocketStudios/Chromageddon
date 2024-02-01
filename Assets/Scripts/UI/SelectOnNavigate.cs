using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace SRS.UI
{
	public class SelectOnnavigate : MonoBehaviour
	{
		[SerializeField] private InputActionReference navigate;

		private GameObject lastSelected;

		private void OnEnable()
		{
			navigate.action.performed += OnNavigate;
		}

        private void OnNavigate(InputAction.CallbackContext context)
        {
            if(!EventSystem.current.alreadySelecting)
			{
				if(lastSelected == null || lastSelected.activeSelf == false)
				{
					EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
				}
				else
				{
					EventSystem.current.SetSelectedGameObject(lastSelected);
				}

				lastSelected = EventSystem.current.currentSelectedGameObject;
			}
        }
    }
}