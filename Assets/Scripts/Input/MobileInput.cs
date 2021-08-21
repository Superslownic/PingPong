using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PingPong
{
    public class MobileInput : MonoBehaviour, IInput, IPointerDownHandler, IDragHandler
    {
        public event Action<float> OnDrag;
        public event Action<float> OnPointerDown;

        private Camera _camera;
        
        public void Init(Camera camera)
        {
            _camera = camera;
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            OnPointerDown(_camera.ScreenToWorldPoint(eventData.position).x);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            OnDrag(_camera.ScreenToWorldPoint(eventData.position).x);
        }
    }
}