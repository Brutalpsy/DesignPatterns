using System.Collections.Generic;
using System.Linq;

namespace CompositePattern
{
    public class DirectoryItem : FileSystemItem
    {
        public  List<FileSystemItem> Items { get; } = new List<FileSystemItem>();
        public DirectoryItem(string name) : base(name)
        {

        }

        public override decimal GetSizeInKB()
        {
            return Items.Sum(x => x.GetSizeInKB());
        }

        public void Add(FileSystemItem fileSystemItem)
        {
            Items.Add(fileSystemItem);
        }

        public void Remove(FileSystemItem fileSystemItem)
        {
            Items.Remove(fileSystemItem);
        }

    }
}
