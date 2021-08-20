namespace PingPong
{
    public class Customizer : IThemeVisitor
    {
        public ITargetView View { get; private set; }
        
        private TargetViewFactory _targetViewFactory;

        public Customizer()
        {
            _targetViewFactory = new TargetViewFactory();
        }

        public void Visit(StandardTheme theme)
        {
            var view = _targetViewFactory.Create<StandardThemeView>();
            view.Setup(theme);
            View = view;
        }

        public void Visit(AdvancedTheme theme)
        {
            var view = _targetViewFactory.Create<AdvancedThemeView>();
            view.Setup(theme);
            View = view;
        }
    }
}
