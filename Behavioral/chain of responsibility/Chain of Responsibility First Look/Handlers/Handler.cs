namespace Chain_of_Responsibility_First_Look.Handlers
{
    public abstract class Handler<T> : IHandler<T> where T : class
    {
        private IHandler<T> _next { get; set; }
        public virtual void Handle(T request)
        {
            _next?.Handle(request);
        }

        public IHandler<T> SetNext(IHandler<T> next)
        {
            _next = next;
            return next;
        }
    }
}
