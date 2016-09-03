using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using finder647.UICodeSample.Data;

namespace finder647.UICodeSample.UI.Deck
{
    [RequireComponent(typeof(RectTransform))]
    public class DeckTooltipController : MonoBehaviour
    {
        [SerializeField]
        private Text _cardNameText;
        [SerializeField]
        private Text _cardDescriptionText;
        [SerializeField]
        private RectTransform _tooltipTransform;

        private void OnDisabled()
        {
            _tooltipTransform.anchoredPosition = Vector3.zero;
        }
        
        public void DisplayTooltip(Vector2 pointerPosition, string name, string description)
        {
           _cardNameText.text = name;
            _cardDescriptionText.text = description;

            UpdateTooltipPosition(pointerPosition);
        }

        public void UpdateTooltipPosition(Vector2 pointerPosition)
        {
            if (_tooltipTransform == null)
                _tooltipTransform = GetComponent<RectTransform>();

            Vector2 newTooltipPosition = pointerPosition;

            if (pointerPosition.x > Screen.width * 0.5f)
            {
                _tooltipTransform.pivot = new Vector2(1, 0);
            }
            else
            {
                _tooltipTransform.pivot = Vector2.zero;
            }

            _tooltipTransform.position = newTooltipPosition;
        }
    }
}