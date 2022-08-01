namespace Telephony

{
    using System;
    using Telephony.Models.Core;
    using Telephony.Models.IO;
    using Telephony.Models.IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWritter writter = new ConsoleWritter();

            IEngine engine = new Engine(reader,writter);
            engine.Start();
        }
    }
}
