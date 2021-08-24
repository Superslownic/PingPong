using UnityEngine;

namespace PingPong
{
    public class TargetFactory
    {
        private SkinContainer _skinContainer;
        private SkinSelectorModel _skinSelector;
        private TargetParametersContainer _parameters;

        public TargetFactory(SkinContainer skinContainer, SkinSelectorModel skinSelector, TargetParametersContainer parameters)
        {
            _skinContainer = skinContainer;
            _skinSelector = skinSelector;
            _parameters = parameters;
        }

        public TargetModel Create(Transform parent)
        {
            Skin skin = _skinContainer.ElementAt(_skinSelector.SelecledIndex);
            var view = Object.Instantiate(skin.view, parent.position, Quaternion.identity, parent).Ctor();
            var model = new TargetModel(view, _parameters.Any());

            return model;
        }
    }
}
