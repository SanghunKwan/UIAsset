using System.Collections.Generic;
using UnityEngine;

namespace SGA.UI
{
    public class WindowManager : MonoBehaviour
    {
        Dictionary<Transform, UIWindow> windowDictionary;
        int childCount;

        private void Awake()
        {
            windowDictionary = new Dictionary<Transform, UIWindow>();
        }
        private void Start()
        {
            childCount = transform.childCount;
            Transform tempTransform;
            UIWindow tempWindow;
            for (int i = 0; i < childCount; i++)
            {
                tempTransform = transform.GetChild(i);
                tempWindow = tempTransform.GetComponent<UIWindow>();

                windowDictionary.Add(tempTransform, tempWindow);

                if (!tempWindow.visibleInStart)
                    tempWindow.SetVisible(false);
            }
        }
        public void SetRecent(UIWindow recentWindow)
        {
            recentWindow.transform.SetAsLastSibling();
        }
        public void CloseRecentWindow()
        {
            UIWindow window = windowDictionary[transform.GetChild(childCount - 1)];
            window.transform.SetAsFirstSibling();
            window.SetVisible(false);
        }
        public void OpenWindow(UIWindow closedWindow)
        {
            closedWindow.SetVisible(true);
            SetRecent(closedWindow);
        }
    }

}
