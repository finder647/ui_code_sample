using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace finder647.UICodeSample.UI
{
    public class OptionController : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _optionPanel;
        [SerializeField]
        private Toggle _optionToggle;

        private void Start()
        {
            if (_optionToggle != null)
            {
                _optionToggle.onValueChanged.AddListener(SetOptionPanelActive);
            }

            SetOptionPanelActive(false);
        }

        public void SetOptionPanelActive(bool active)
        {
            if (_optionPanel != null)
            {
                _optionPanel.gameObject.SetActive(active);
            }            
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
