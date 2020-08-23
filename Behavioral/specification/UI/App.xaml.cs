using Logic.Utils;

namespace UI
{
    public partial class App
    {
        public App()
        {
            Initer.Init(@"Server=localhost;Database=SpecPattern;Trusted_Connection=true;");
        }
    }
}
