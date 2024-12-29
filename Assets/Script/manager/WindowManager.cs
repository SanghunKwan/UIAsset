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
            for (int i = 0; i < childCount; i++)
            {
                tempTransform = transform.GetChild(i);
                windowDictionary.Add(tempTransform, tempTransform.GetComponent<UIWindow>());
                windowDictionary[tempTransform].SetVisible(false);
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
