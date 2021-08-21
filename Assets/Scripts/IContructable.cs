namespace PingPong
{
    public interface IContructable
    {
        void Ctor();
    }

    public interface IContructable<T>
    {
        void Ctor(T dependency);
    }

    public interface IContructable<T1, T2>
    {
        void Ctor(T1 dependency1, T2 dependency2);
    }

    public interface IContructable<T1, T2, T3>
    {
        void Ctor(T1 dependency1, T2 dependency2, T3 dependency3);
    }
}
