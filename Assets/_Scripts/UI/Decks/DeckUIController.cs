using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using finder647.UICodeSample.Util;

namespace finder647.UICodeSample.UI.Deck
{
    public class DeckUIController : MonoBehaviour
    {
        public bool IsDisplayingTooltip
        {
            get
            {
                return _currentTooltip.gameObject.activeInHierarchy;
            }
        }

        public DeckTooltipController CurrentTooltip
        {
            get { return _currentTooltip; }
        }

        [SerializeField]
        private GridLayoutGroup _deckGrid;
        [SerializeField]
        private Scrollbar _deckScrollbar;
        [SerializeField]
        private Image _selectedCardImage;
        [SerializeField]
        private DeckTooltipController _currentTooltip;

        private bool _showingTooltip;

        private void Start()
        {
            InitializeDeckUI();
        }

        private void InitializeDeckUI()
        {
            _deckScrollbar.value = 0;

            InstantiateTooltip();
        }

        private DeckTooltipController InstantiateTooltip()
        {
            GameObject tooltipGO = (GameObject)Instantiate(Resources.Load(Constants.DECK_TOOLTIP_PATH));
            tooltipGO.SetActive(false);
            _currentTooltip = tooltipGO.GetComponent<DeckTooltipController>();
            
            if (_currentTooltip != null)
            {
                _currentTooltip.transform.SetParent(transform);
                _currentTooltip.transform.localScale = Vector3.one;
            }
            else
            {
                Debug.LogWarning("Failed to load tooltip from Resource path..");
            }

            return _currentTooltip;
        }

        public void SetSelectedCardImage(Sprite cardSprite)
        {
            _selectedCardImage.sprite = cardSprite;
        }

        public void ShowToolTip(Vector2 pointerPosition, CardOnDeck hoveredCard)
        {
            if (_currentTooltip == null)
            {
                if (InstantiateTooltip() == null)
                {
                    return;
                }
            }

            _currentTooltip.gameObject.SetActive(true);
            _currentTooltip.DisplayTooltip(pointerPosition, hoveredCard.name, hoveredCard.CardDesc);
        }

        public void HideToolTip()
        {
            if (_currentTooltip != null)
            {
                _currentTooltip.gameObject.SetActive(false);
            }
        }
    }
}
