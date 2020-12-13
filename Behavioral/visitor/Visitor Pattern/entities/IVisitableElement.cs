namespace Visitor_Pattern
{
    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }
}
