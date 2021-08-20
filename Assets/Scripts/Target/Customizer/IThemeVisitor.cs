namespace PingPong
{
    public interface IThemeVisitor
    {
        void Visit(StandardTheme theme);
        void Visit(AdvancedTheme theme);
    }
}
