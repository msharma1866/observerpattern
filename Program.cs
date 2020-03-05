using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Infosys infy = new Infosys("INFY", 750.01f);
            infy.Attach(new MyObserver("Manish_Observer", infy));

            infy.Price = 755.50f;
        }
    }
}
