using UnityEngine;
using UnityEngine.EventSystems;
using finder647.UICodeSample.Data;
using System;

namespace finder647.UICodeSample.UI.Deck
{
    public class CardOnDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public string CardName
        {
            get { return _cardData.name; }
        }

        public string CardDesc
        {
            get { return _cardData.description; }
        }

        public Sprite CardAvatar
        {
            get { return _cardData.avatar; }
        }

        [SerializeField]
        private CardData _cardData;
        [SerializeField]
        private float _clickTimeThreshold = 0.5f;
        [SerializeField]
        private float _showTooltipTimeThreshold = 0.75f;

        private DeckUIController _deckController;
        private Vector2 _pointerDownPosition;
        private float _pointerDownTime;
        private float _pointerEnterTime;
        private bool _pointerHover;

        private void Awake()
        {
            _deckController = GetComponentInParent<DeckUIController>();
            _pointerHover = false;
        }

        private void Update()
        {
            if (_pointerHover)
            {
                if (Time.time - _pointerEnterTime > _showTooltipTimeThreshold)
                {
                    if (!_deckController.IsDisplayingTooltip)
                        _deckController.ShowToolTip(Input.mousePosition, this);
                    
                    _deckController.CurrentTooltip.UpdateTooltipPosition(Input.mousePosition);
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _pointerEnterTime = Time.time;
            _pointerHover = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _deckController.HideToolTip();
            _pointerHover = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerDownPosition = eventData.position;
            _pointerDownTime = Time.time;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (Time.time - _pointerDownTime > _clickTimeThreshold && eventData.position.Equals(_pointerDownPosition))
            {
                _deckController.SetSelectedCardImage(CardAvatar);
            }
        }
    }
}