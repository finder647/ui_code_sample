using UnityEngine;
using System.Collections;

namespace finder647.UICodeSample.UI
{
    public class CurtainController : MonoBehaviour
    {
        public bool IsMovingCurtain
        {
            get { return _isMovingCurtain; }
        }

        public bool IsCurtainOpened
        {
            get
            {
                if (_topCurtain.anchoredPosition.y == _openedTopCurtainPosition.y &&
                    _bottomCurtain.anchoredPosition.y == _openedBotCurtainPosition.y)
                {
                    return true;
                }                    
                else
                {
                    return false;
                }
            }
        }

        [SerializeField]
        private RectTransform _topCurtain;
        [SerializeField]
        private RectTransform _bottomCurtain;
        [SerializeField]
        private Vector2 _openedTopCurtainPosition;
        [SerializeField]
        private Vector2 _openedBotCurtainPosition;
        [SerializeField]
        private Vector2 _closedTopCurtainPosition= Vector2.zero;
        [SerializeField]
        private Vector2 _closedBotCurtainPosition = Vector2.zero;
        [SerializeField]
        private float _curtainMoveSpeed = 10;

        private bool _isMovingCurtain;

        public void OpenCurtain()
        {
            StartCoroutine(MoveCurtain(_topCurtain, _openedTopCurtainPosition));
            StartCoroutine(MoveCurtain(_bottomCurtain, _openedBotCurtainPosition));
        }

        public void CloseCurtain()
        {
            StartCoroutine(MoveCurtain(_topCurtain, _closedTopCurtainPosition));
            StartCoroutine(MoveCurtain(_bottomCurtain, _closedBotCurtainPosition));
        }

        private IEnumerator MoveCurtain(RectTransform curtainTransform, Vector2 targetPosition)
        {
            if (curtainTransform != null)
            {
                _isMovingCurtain = true;

                while (!curtainTransform.anchoredPosition.Equals(targetPosition))
                {
                    curtainTransform.anchoredPosition = Vector2.Lerp(curtainTransform.anchoredPosition, targetPosition, _curtainMoveSpeed * Time.deltaTime);

                    yield return new WaitForEndOfFrame();
                }

                curtainTransform.anchoredPosition = targetPosition;

                _isMovingCurtain = false;

            }
        }
    }
}
