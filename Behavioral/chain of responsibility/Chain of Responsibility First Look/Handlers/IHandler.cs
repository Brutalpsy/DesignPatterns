namespace Chain_of_Responsibility_First_Look.Handlers
{
    public interface IHandler<T> where T : class
    {
        IHandler<T> SetNext(IHandler<T> next);
        void Handle(T request);
    }
}
