

namespace Telephony.Models.IO
{
    using System;
    using Interfaces;
    public class ConsoleWritter : IWritter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
