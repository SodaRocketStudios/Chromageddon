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
            if(pointerClickAudio != null)
            {
                audioSource.PlayOneShot(pointerClickAudio);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(pointerDownAudio != null)
            {
                audioSource.PlayOneShot(pointerDownAudio);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(pointerEnterAudio != null)
            {
                audioSource.PlayOneShot(pointerEnterAudio);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(pointerExitAudio != null)
            {
                audioSource.PlayOneShot(pointerExitAudio);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if(pointerUpAudio != null)
            {
                audioSource.PlayOneShot(pointerUpAudio);
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            if(pointerEnterAudio != null)
            {
                audioSource.PlayOneShot(pointerEnterAudio);
            }
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if(pointerClickAudio != null)
            {
                audioSource.PlayOneShot(pointerClickAudio);
            }
        }

        public void OnCancel(BaseEventData eventData)
        {
            if(pointerUpAudio != null)
            {
                audioSource.PlayOneShot(pointerUpAudio);
            }
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if(pointerExitAudio != null)
            {
                audioSource.PlayOneShot(pointerExitAudio);
            }
        }
    }
}