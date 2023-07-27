using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace SRS.UI
{
    public class HoldButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField, Min(0.1f)] private float holdTime = 1;


        public UnityEvent<float> OnHoldUpdated;
        public UnityEvent OnHoldCompleted;
        public UnityEvent OnPointerEnterEvent;
        public UnityEvent OnPointerExitEvent;
        public UnityEvent OnPointerUpEvent;
        public UnityEvent OnPointerDownEvent;

        private float timeHeld = 0;
        private float holdPercentage = 0;

        private bool isHeld = false;

        private void Update()
        {
            if(isHeld)
            {
                HandleHold();
            }
            else if(holdPercentage > 0)
            {
                HandleRelease();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterEvent?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isHeld = false;
            OnPointerUpEvent?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isHeld = true;
        }

        private void HandleHold()
        {
            timeHeld += Time.unscaledDeltaTime;

            holdPercentage = Mathf.Clamp01(timeHeld/holdTime);

            OnHoldUpdated?.Invoke(holdPercentage);

            if(holdPercentage >= 1)
            {
                OnHoldCompleted?.Invoke();
            }
        }

        private void HandleRelease()
        {
            timeHeld -= Time.unscaledDeltaTime;

            holdPercentage = Mathf.Clamp01(timeHeld/holdTime);

            OnHoldUpdated?.Invoke(holdPercentage);
        }
    }
}
