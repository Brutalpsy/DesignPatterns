namespace Visitor___First_Look
{
    public class ComponentB : IComponent
    {
        public void Accept(IVisitor visitor) => visitor.VisitComponentB(this);

        public string ExclusiveMethodOfComponentB => "B";
    }
}
