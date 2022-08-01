namespace Telephony.Models.Core
{
    using System;
    using Telephony.Models.IO.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWritter writter;

        private readonly SmartPhone smartPhone;
        private readonly StationaryPhone stationaryPhone;

        private Engine()
        {
            this.smartPhone = new SmartPhone();
            this.stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWritter writter)
            : this()
        {
            this.reader = reader;
            this.writter = writter;
        }
        public void Start()
        {
            string[] phoneNumbers = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in phoneNumbers)
            {
                if (!this.ValidateNumber(number))
                {
                    this.writter.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    this.writter.WriteLine(this.smartPhone.Call(number));
                }
                else if (number.Length == 7)
                {
                  this.writter.WriteLine(this.stationaryPhone.Call(number));
                }
            }

            foreach (var url in urls)
            {
                if (!this.ValidateURL(url))
                {
                    this.writter.WriteLine("Invalid URL!");
                }
                else 
                {
                    this.writter.WriteLine(this.smartPhone.BrowseURL(url));
                }
            }
        }
        private bool ValidateNumber(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateURL(string url)
        {
            foreach (var ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
