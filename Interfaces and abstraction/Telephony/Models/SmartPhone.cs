
namespace Telephony
{
using Telephony.Models.Interfaces;
    public class SmartPhone : ICallable,IBrowseble
    {
        public string BrowseURL(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
