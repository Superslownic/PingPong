using System;
using UnityEngine;

namespace PingPong
{
    public class SkinSelectorModel
    {
        private readonly SkinSelectorView _view;
        private readonly SkinContainer _skinContainer;

        public event Action OnSkinChanged;

        public int SelecledIndex { get; private set; }

        public SkinSelectorModel(SkinSelectorView view, SkinContainer skinContainer)
        {
            _view = view;
            _view.OnOpen += GlobalStateMachine.Instance.SetState<Customize>;
            _view.OnClose += GlobalStateMachine.Instance.SetState<Play>;
            _view.OnNextButtonDown += NextHandler;
            _view.OnPrevButtonDown += PrevHandler;
            _skinContainer = skinContainer;
            SelecledIndex = GameData.Instance.Get("SelectedSkin", 0);
        }

        public void Open()
        {
            _view.Open();
            Show();
        }

        public void Close()
        {
            _view.Close();
        }

        private void NextHandler()
        {
            SelecledIndex += 1;
            Show();
        }

        private void PrevHandler()
        {
            SelecledIndex -= 1;
            Show();
        }

        private void Show()
        {
            SelecledIndex = (int)Mathf.Repeat(SelecledIndex, _skinContainer.Count);
            GameData.Instance.Set("SelectedSkin", SelecledIndex);
            _view.ShowSkin(_skinContainer.ElementAt(SelecledIndex).showcase);
        }
    }
}
