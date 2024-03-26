using UnityEngine;
using UnityEngine.EventSystems;
using SRS.Audio;

namespace SRS.UI
{
    public class UIAudioPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler, ISubmitHandler, ICancelHandler
    {
        
		[SerializeField] private Sound pointerEnterSound;
		[SerializeField] private Sound pointerExitSound;
		[SerializeField] private Sound pointerDownSound;
		[SerializeField] private Sound pointerUpSound;
		[SerializeField] private Sound pointerClickSound;

        public void OnPointerClick(PointerEventData eventData)
        {
            Play(pointerClickSound);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Play(pointerDownSound);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Play(pointerEnterSound);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Play(pointerExitSound);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Play(pointerUpSound);
        }

        public void OnSelect(BaseEventData eventData)
        {
            Play(pointerEnterSound);
        }

        public void OnSubmit(BaseEventData eventData)
        {
            Play(pointerClickSound);
        }

        public void OnCancel(BaseEventData eventData)
        {
            Play(pointerUpSound);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            Play(pointerExitSound);
        }

        private void Play(Sound sound)
        {
            AudioManager.Instance.Play(sound);
        }
    }
}