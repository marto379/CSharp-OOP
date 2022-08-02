
namespace BorderControl
{
    using BorderControl.Core;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Start();
        }
    }
}
