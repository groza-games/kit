using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GrozaGames.Kit
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private const float LONG_PRESS_DURATION = 0.5f;
        
        [Header("Components")]
        [SerializeField] protected Button _button;
        [SerializeField] protected RectTransform _rectTransform;
        
        [Header("Other")]
        [SerializeField] private bool _disablePressedEffect = true;

        public event Action OnClick;
        public event Action OnLongPressStart;
        public event Action<float> OnLongPressUpdate;
        public event Action OnLongPressClick;
        public event Action<bool> OnInteractableChanged;
        public event Action<bool> OnHoverChanged;
        
        public RectTransform RectTransform => _rectTransform;
        
        public Image ButtonGraphic => _button.image;

        private bool _longPressed;
        private bool _isPointerDown;
        private float _pressDuration;

        public bool Interactable
        {
            get => _button.interactable;
            set
            {
                if (_button.interactable == value)
                    return;

                _button.interactable = value;
                OnInteractableChanged?.Invoke(value);
            }
        }

        public bool IsPressing => _isPointerDown;

        private void Reset()
        {
            _button = GetComponent<Button>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ProcessClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ProcessClick);
        }

        private void ProcessClick()
        {
            if (_longPressed)
            {
                _longPressed = false;
                OnLongPressClick?.Invoke();
            }
            else
            {
                OnClick?.Invoke();
            }
        }

        private void Update()
        {
            UpdateLongPress();
        }

        private void UpdateLongPress()
        {
            if (_isPointerDown)
            {
                _pressDuration += Time.deltaTime;

                if (_pressDuration > LONG_PRESS_DURATION)
                {
                    if (!_longPressed)
                    {
                        _longPressed = true;
                        OnLongPressStart?.Invoke();
                    }

                    OnLongPressUpdate?.Invoke(_pressDuration);
                }
            }
            else
            {
                _pressDuration = 0;
            }
        }

        private void DisablePressedEffect()
        {
            if (!_disablePressedEffect) 
                return;
            if (!EventSystem.current) 
                return;
            if (EventSystem.current.currentSelectedGameObject == gameObject)
                EventSystem.current.SetSelectedGameObject(null);
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            _isPointerDown = true;
            _longPressed = false;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            _isPointerDown = false;
            DisablePressedEffect();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnHoverChanged?.Invoke(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnHoverChanged?.Invoke(false);
        }
    }
}