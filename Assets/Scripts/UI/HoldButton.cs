using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SRS.UI
{
    public class HoldButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField, Min(0.1f)] private float holdTime = 1;
        [SerializeField, Min(0.1f)] private float hoverDelay = 1;


        public UnityEvent<float> OnHoldUpdated;
        public UnityEvent OnHoldCompleted;
        public UnityEvent OnCompleted;
        public UnityEvent OnPointerEnterEvent;
        public UnityEvent OnPointerExitEvent;
        public UnityEvent OnPointerUpEvent;
        public UnityEvent OnPointerDownEvent;
        public UnityEvent<Vector2> OnPointerHoverEvent;
        public UnityEvent OnPointerHoverEndEvent;

        private float timeHeld = 0;
        private float holdProgress = 0;
        private bool isHeld = false;

        private float hoverTime;
        private bool isHovering = false;
        private bool wasHovering = false;

        private bool holdComplete = false;

        private Mouse mouse;
        private new Camera camera;

        private void Awake()
        {
            mouse = Mouse.current;
            camera = camera = Camera.main;
        }

        private void Update()
        {
            if(isHeld)
            {
                if(!holdComplete)
                {
                    HandleHold();
                }
            }
            else if(holdProgress > 0)
            {
                HandleRelease();
            }
            else if(isHovering)
            {
                HandleHover();
            }

            if(isHovering == false)
            {
                if(wasHovering)
                {
                    wasHovering = false;
                    OnPointerHoverEndEvent?.Invoke();
                    ResetHoverTime();
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterEvent?.Invoke();
            isHovering = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitEvent?.Invoke();
            isHovering = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isHeld = false;
            isHovering = true;
            holdComplete = false;
            OnPointerUpEvent?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isHeld = true;
            isHovering = false;
        }

        private void HandleHold()
        {
            timeHeld += Time.unscaledDeltaTime;

            holdProgress = Mathf.Clamp01(timeHeld/holdTime);

            OnHoldUpdated?.Invoke(holdProgress);

            if(holdProgress >= 1)
            {
                holdComplete = true;
                OnHoldCompleted?.Invoke();
            }
        }

        private void HandleRelease()
        {
            if(holdProgress >= 1)
            {
                OnCompleted?.Invoke();
            }

            timeHeld -= Time.unscaledDeltaTime;

            holdProgress = Mathf.Clamp01(timeHeld/holdTime);

            OnHoldUpdated?.Invoke(holdProgress);
        }

        private void HandleHover()
        {
            hoverTime += Time.unscaledDeltaTime;

            if(hoverTime >= hoverDelay)
            {
                wasHovering = true;
                OnPointerHoverEvent?.Invoke(camera.ScreenToWorldPoint(mouse.position.value));
            }
        }

        private void ResetHoverTime()
        {
            hoverTime = 0;
        }
    }
}