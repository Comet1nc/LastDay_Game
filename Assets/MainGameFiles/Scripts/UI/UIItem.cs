using UnityEngine;
using UnityEngine.EventSystems;

namespace MainGameFiles.Scripts.UI
{
    public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        protected CanvasGroup _canvasGroup;
        private Canvas _mainCanvas;
        protected RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _mainCanvas = GetComponentInParent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            var slotTransform = _rectTransform.parent;
            slotTransform.SetAsLastSibling();
            _canvasGroup.blocksRaycasts = false;
        }


        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}
