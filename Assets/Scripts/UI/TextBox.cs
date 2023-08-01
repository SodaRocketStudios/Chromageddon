using UnityEngine;
using TMPro;

namespace SRS.UI
{
    public class TextBox : MonoBehaviour
    {
        private TMP_Text textObject;

        private void Awake()
        {
            textObject = GetComponent<TMP_Text>();
        }

        public void SetText(string newText)
        {
            textObject.text = newText;
        }
    }
}
