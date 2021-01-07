using CompositePattern.Structural;
using Newtonsoft.Json;
using System;
using System.Xml.Linq;

namespace CompositePattern
{
    class Program
    {
        //Client
        static void Main(string[] args)
        {
            //StructuralExample();

            //LeveragingAlreadyBuiltInComposite();

            //FileSystemComposite();

            BuilderExample();
        }



        private static void BuilderExample()
        {
            var builder = new FileSystemBuilder("development");
            builder.AddDirectory("project1");
            builder.AddFile("p1f1.txt", 2100);
            builder.AddFile("p2f2.txt", 3100);
            builder.AddDirectory("sub-dir");
            builder.AddFile("p1f3.txt", 4100);
            builder.AddFile("p1f4.txt", 5100);

            builder.SetCurrentDirectory("development");
            builder.AddDirectory("project2");
            builder.AddFile("p2f1.txt", 4100);
            builder.AddFile("p2f2.txt", 5100);

            Console.WriteLine($"Total size (root): {builder.Root.GetSizeInKB()} KB");
            Console.WriteLine(JsonConvert.SerializeObject(builder.Root, Formatting.Indented));
        }


        private static void FileSystemComposite()
        {
            var root = new DirectoryItem("development");
            var proj1 = new DirectoryItem("project 1");
            var proj2 = new DirectoryItem("project 2");
            root.Add(proj1);
            root.Add(proj2);

            proj1.Add(new FileItem("p1f1.text", 2100));
            proj1.Add(new FileItem("p1f2.text", 3100));

            var subdir1 = new DirectoryItem("sub-dir1");
            subdir1.Add(new FileItem("p1f3.text", 4100));
            subdir1.Add(new FileItem("p1f4.text", 5100));
            proj1.Add(subdir1);


            proj2.Add(new FileItem("p2f1.text", 6100));
            proj2.Add(new FileItem("p2f2.text", 7100));

            Console.WriteLine($"Total size (project2): {proj2.GetSizeInKB()} KB");
            Console.WriteLine($"Total size (project1): {proj1.GetSizeInKB()} KB");
            Console.WriteLine($"Total size (root): {root.GetSizeInKB()} KB");
        }
        private static void LeveragingAlreadyBuiltInComposite()
        {
            var xml = XElement.Load("file-system.xml");

            foreach (var leaf in xml.FindElements(x => !x.HasElements))
            {
                Console.WriteLine($"****** LEAF: {leaf.Attribute("name")}, {leaf.Attribute("fileBytes")}");
            }
        }

        private static void StructuralExample()
        {
            //Create a tree structure
            var root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp1 = new Composite("Composite C1");
            comp1.Add(new Leaf("Leaf C1-A"));
            comp1.Add(new Leaf("Leaf C1-B"));

            var comp2 = new Composite("Composite C2");
            comp2.Add(new Leaf("Leaf C2-A"));

            comp1.Add(comp2);

            root.Add(comp1);
            root.Add(new Leaf("Leaf C"));

            //add and remove a leaf
            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.PrimaryOperation(1);
        }
    }
}
