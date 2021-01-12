using System.IO;
using System.Text;
using Xunit;

namespace ProxyPattern.SmartProxy.Tests
{
    public class FileConcurrentWrites
    {
        const string TEST_FILE = "output.txt";

        [Fact]
        public void RaisesExceptionWithDirectFileAccess()
        {
            var fs = new DefaultFile();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. first\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("1. second\n");


            using var file = fs.OpenWrite(TEST_FILE);
            Assert.Throws<IOException>(() => fs.OpenWrite(TEST_FILE));

            file.Write(outputBytes1);
            //file2.Write(outputBytes2); // we never get here

            file.Close();
            //file2.Close(); // we never get here
        }

        [Fact]
        public void ManageReferences()
        {
            var fs = new FileSmartProxy();

            byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. first\n");
            byte[] outputBytes2 = Encoding.ASCII.GetBytes("1. second\n");

            using var file1 = fs.OpenWrite(TEST_FILE);
            using var file2 = fs.OpenWrite(TEST_FILE);

            file1.Write(outputBytes1);
            file2.Write(outputBytes2);

            file1.Close();
            file2.Close();
        }
    }
}
