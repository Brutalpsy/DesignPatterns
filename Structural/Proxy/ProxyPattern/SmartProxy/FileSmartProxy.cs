using System;
using System.Collections.Generic;
using System.IO;

namespace ProxyPattern.SmartProxy
{
    public class FileSmartProxy: IFile
    {
        private readonly Dictionary<string, FileStream> _openStreams = new Dictionary<string, FileStream>();

        public FileStream OpenWrite(string path)
        {
            try
            {
                var stream = File.OpenWrite(path);
                _openStreams.Add(path, stream);

                return stream;
            }
            catch (Exception ex)
            {
                if (_openStreams.ContainsKey(path))
                {
                    var stream = _openStreams[path];
                    if(stream != null && stream.CanWrite)
                    {
                        return stream;
                    }
                }
                throw;
            }
        }
    }
}
