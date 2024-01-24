using UnityEngine;
using UnityEngine.EventSystems;

namespace SRS.UI
{
    public class UIAudioPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler, ISubmitHandler, ICancelHandler
    {
		[SerializeField] private AudioSource audioSource;

		[SerializeField] private AudioClip pointerEnterAudio;
		[SerializeField] private AudioClip pointerExitAudio;
		[SerializeField] private AudioClip pointerDownAudio;
		[SerializeField] private AudioClip pointerUpAudio;
		[SerializeField] private AudioClip pointerClickAudio;


        public void OnPointerClick(PointerEventData eventData)
        {
            audioSource.PlayOneShot(pointerClickAudio);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            audioSource.PlayOneShot(pointerDownAudio);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            audioSource.PlayOneShot(pointerEnterAudio);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            audioSource.PlayOneShot(pointerExitAudio);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            audioSource.PlayOneShot(pointerUpAudio);
        }

        public void OnSelect(BaseEventData eventData)
        {
            audioSource.PlayOneShot(pointerEnterAudio);
        }

        public void OnSubmit(BaseEventData eventData)
        {
            audioSource.PlayOneShot(pointerClickAudio);
        }

        public void OnCancel(BaseEventData eventData)
        {
            audioSource.PlayOneShot(pointerUpAudio);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            audioSource.PlayOneShot(pointerExitAudio);
        }
    }
}