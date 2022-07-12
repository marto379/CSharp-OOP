using System;
using System.Runtime.Serialization;

namespace Animals
{
    [Serializable]
    internal class ArgumentNullExeption : Exception
    {
        private string v1;
        private string v2;

        public ArgumentNullExeption()
        {
        }

        public ArgumentNullExeption(string message) : base(message)
        {
        }

        public ArgumentNullExeption(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public ArgumentNullExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentNullExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}