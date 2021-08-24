using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PingPong
{
    public class SkinSelectorView : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _prevButton;
        
        public event UnityAction OnOpen;
        public event UnityAction OnClose;
        public event UnityAction OnNextButtonDown;
        public event UnityAction OnPrevButtonDown;

        private Object _currentSkin;

        public SkinSelectorView Ctor()
        {
            _openButton.onClick.AddListener(OnOpen);
            _closeButton.onClick.AddListener(OnClose);
            _nextButton.onClick.AddListener(OnNextButtonDown);
            _prevButton.onClick.AddListener(OnPrevButtonDown);

            return this;
        }

        public void ShowSkin(Object skin)
        {
            if (_currentSkin != null)
                Destroy(_currentSkin);

            _currentSkin = Instantiate(skin, _point);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            if (_currentSkin != null)
                Destroy(_currentSkin);

            gameObject.SetActive(false);
        }
    }
}
