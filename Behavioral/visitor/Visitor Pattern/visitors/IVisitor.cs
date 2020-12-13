namespace Visitor_Pattern
{
    public interface IVisitor
    {
        void VisitBook(Book book);
        void VisitVinyl(Vinyl vinyl);
        void Print();
    }
}
