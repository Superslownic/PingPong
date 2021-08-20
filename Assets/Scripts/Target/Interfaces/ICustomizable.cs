namespace PingPong
{
    public interface ICustomizable<TTheme>
    {
        void Customize(TTheme theme);
    }

    public interface ICustomizable<T1, T2>
    {
        void Customize(T1 t1, T2 t2);
    }
}
