using UnityEngine;

namespace SRS.UI
{
    public class HoverDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject displayElement;

        public void Show(Vector2 position)
        {
            displayElement.SetActive(true);
            
            displayElement.transform.position = position;
        }

        public void Hide()
        {
            displayElement.SetActive(false);
        }

        public void UpdatePosition(Vector2 position)
        {
            displayElement.transform.position = position;
        }
    }
}
