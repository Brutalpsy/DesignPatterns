using static System.Console;

namespace Visitor___First_Look
{
    public class ConcreateVisitor2 : IVisitor
    {
        public void VisitComponentA(ComponentA componentA)
         => WriteLine($"{componentA.ExclusiveMethodOfComponentA} + {nameof(ConcreateVisitor2)}");

        public void VisitComponentB(ComponentB componentB)
           => WriteLine($"{componentB.ExclusiveMethodOfComponentB} + {nameof(ConcreateVisitor2)}");
    }
}
