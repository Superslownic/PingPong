namespace PingPong
{
    public interface IConfigurable<TParams>
    {
        void SetParams(TParams parameters);
    }
}
