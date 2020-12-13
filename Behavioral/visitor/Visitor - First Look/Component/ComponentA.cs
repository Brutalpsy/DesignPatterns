namespace Visitor___First_Look
{
    public class ComponentA : IComponent
    {
        public void Accept(IVisitor visitor) => visitor.VisitComponentA(this);

        public string ExclusiveMethodOfComponentA => "A"; 
    }
}
