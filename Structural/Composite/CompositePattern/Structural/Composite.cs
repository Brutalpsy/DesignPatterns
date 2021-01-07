using System;
using System.Collections.Generic;

namespace CompositePattern.Structural
{
    public class Composite : Component
    {
        readonly List<Component> _children = new List<Component>();
        public Composite(string name) : base(name)
        {
        }

        public void Add(Component component)
        {
            _children.Add(component);
        }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new String('-',depth)+this.Name);
            foreach(var component in _children)
            {
                component.PrimaryOperation(depth + 2);
            }
        }

        public void Remove(Component component)
        {
            _children.Remove(component);
        }
    }
}
