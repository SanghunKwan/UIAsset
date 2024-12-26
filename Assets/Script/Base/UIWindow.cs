using System;
using UnityEngine;

namespace SGA.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIWindow : MonoBehaviour
    {
        RectTransform m_rectTransform;

        [SerializeField] bool isVisible;

        public Action InvisibleAction { get; set; }

        Vector3 originalPosition;

        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
            originalPosition = m_rectTransform.position;
        }

        public void SetVisible(bool onoff)
        {
            if (isVisible == onoff)
                return;

            isVisible = onoff;
            if (!isVisible)
                InvisibleAction?.Invoke();

            m_rectTransform.anchoredPosition += TrueOneFalseMinus(isVisible) * Screen.height * 2 * Vector2.up;

        }

        #region calculate
        int TrueOneFalseMinus(bool boolean)
        {
            return (Convert.ToInt32(boolean) * 2) - 1;
        }
        #endregion

        #region 외부 이벤트
        public void ReturnPosition()
        {
            m_rectTransform.position = originalPosition;
        }
        #endregion

    }


}
