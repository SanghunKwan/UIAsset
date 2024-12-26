
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace SGA.UI
{
    [RequireComponent(typeof(UIWindow))]
    public class WindowDraggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        Image image;
        [SerializeField] RectTransform dragArea;
        Texture2D textureForPixel;
        UIWindow window;

        Vector2 beginDragRectPosition;

        [TooltipAttribute("if It's true, it will Check image Color.")]
        public bool DragAreaDetermineByAlpha;
        bool isDragging;
        [TooltipAttribute("if It's true, it return startPosition when window turn off.")]
        public bool windowOffReturnPosition;

        private void Awake()
        {
            image = GetComponent<Image>();

            textureForPixel = image.mainTexture as Texture2D;
            window = GetComponent<UIWindow>();

            if (windowOffReturnPosition)
                window.InvisibleAction += window.ReturnPosition;
        }
        #region DragEvent
        public void OnBeginDrag(PointerEventData eventData)
        {
            isDragging = RectTransformUtility.RectangleContainsScreenPoint(dragArea, eventData.position);

            beginDragRectPosition = image.rectTransform.position;

            if (!DragAreaDetermineByAlpha && !isDragging)
                return;

            Vector2 vec = MouseNormalized(eventData.position);
            Color pixelColor = textureForPixel.GetPixelBilinear(vec.x, vec.y);
            isDragging &= pixelColor.a >= 0.1f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!isDragging)
                return;

            image.rectTransform.position = eventData.position - eventData.pressPosition + beginDragRectPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            beginDragRectPosition = Vector2.zero;
            isDragging = false;
        }
        #endregion
        #region calculate
        Vector2 MouseNormalized(in Vector2 mousePosition)
        {
            RectTransform rTransform = image.rectTransform;
            return (mousePosition - (Vector2)rTransform.TransformPoint(rTransform.rect.min)) / rTransform.sizeDelta;
        }

        #endregion
        #region uiWindow action Event
        void ReturnPosition()
        {

        }

        #endregion
    }
    public enum DragAreaType
    {
        Rectangle,
        ByAlpha
    }
}