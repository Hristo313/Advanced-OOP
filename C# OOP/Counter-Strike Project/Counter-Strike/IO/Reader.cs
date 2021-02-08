namespace Counter_Strike.IO
{
    using Counter_Strike.IO.Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
