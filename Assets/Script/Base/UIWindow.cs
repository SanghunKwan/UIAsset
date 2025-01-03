using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SGA.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIWindow : MonoBehaviour, IPointerDownHandler
    {
        RectTransform m_rectTransform;

        bool m_isVisible = true;
        public bool isVisible { get { return m_isVisible; } }
        public bool visibleInStart;

        public Action InvisibleAction { get; set; }

        Vector3 originalPosition;

        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
            originalPosition = m_rectTransform.position;
        }

        public void SetVisible(bool onoff)
        {
            if (m_isVisible == onoff)
                return;

            m_isVisible = onoff;
            if (!m_isVisible)
                InvisibleAction?.Invoke();

            m_rectTransform.anchoredPosition += TrueOneFalseMinus(m_isVisible) * Screen.height * 2 * Vector2.up;

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


        public void OnPointerDown(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }
        #endregion

    }


}
