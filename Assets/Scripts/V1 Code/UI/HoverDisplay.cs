using UnityEngine;
using TMPro;

namespace SRS.UI
{
    public class HoverDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject displayElement;
        [SerializeField] private TextBox textBox;

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

        public void SetText(string text)
        {
            textBox.SetText(text);
        }
    }
}
