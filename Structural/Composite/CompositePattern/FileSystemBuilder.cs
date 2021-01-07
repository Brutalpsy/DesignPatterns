using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositePattern
{
    public class FileSystemBuilder
    {
        public DirectoryItem Root { get; }

        private DirectoryItem _currentDirectory;

        public FileSystemBuilder(string rootdirectory)
        {
            Root = new DirectoryItem(rootdirectory);
            _currentDirectory = Root;
        }

        public FileItem AddFile(string name, long size)
        {
            var dir = new FileItem(name, size);
            _currentDirectory.Add(new FileItem(name, size));

            return dir;
        }

        public DirectoryItem AddDirectory(string name)
        {
            var dir = new DirectoryItem(name);
            _currentDirectory.Add(dir);
            _currentDirectory = dir;
            return dir;
        }

        public DirectoryItem SetCurrentDirectory(string directoryName)
        {
            var dirStack = new Stack<DirectoryItem>();
            dirStack.Push(Root);
            while (dirStack.Any())
            {
                var current = dirStack.Pop();
                if(current.Name == directoryName)
                {
                    _currentDirectory = current;
                    return current;
                }

                foreach (var item in current.Items.OfType<DirectoryItem>())
                {
                    dirStack.Push(item);
                }
            }

            throw new InvalidOperationException($"Directory name '{directoryName}' not found!");
        }

        //public FileSystemItem Build () => _currentDirectory;

    }
}
