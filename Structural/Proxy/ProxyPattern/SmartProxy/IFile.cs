using System.IO;

namespace ProxyPattern.SmartProxy
{
    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
}
