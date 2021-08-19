using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPong
{
    public class MobileInput : MonoBehaviour, IInput, IPointerDownHandler, IDragHandler
    {
        private Camera _camera;

        public Vector3 TouchPosition { get; private set; }

        public void Init(Camera camera)
        {
            _camera = camera;
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            CalculatePosition(eventData);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            CalculatePosition(eventData);
        }

        private void CalculatePosition(PointerEventData eventData)
        {
            TouchPosition = _camera.ScreenToWorldPoint(eventData.position);
        }
    }
}