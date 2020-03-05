using System;
using System.Collections.Generic;

namespace Observer
{
    // subject
    public abstract class Stock
    {
        private List<IObserver> observers = new List<IObserver>();
        public string Symbol { get; set; }
        private float _price;

        public Stock(string symbol, float price)
        {
            Symbol = symbol;
            _price = price;
        }
        public float Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
        public void Attach(IObserver obs)
        {
            observers.Add(obs);
        }

        public void DeAttach(IObserver obs)
        {
            observers.Remove(obs);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    public class Infosys : Stock
    {
        public Infosys(string _symbol, float _price) : base(_symbol, _price) { }

    }

    public class SBI : Stock
    {
        public SBI(string _symbol, float _price) : base(_symbol, _price) { }
    }
    public interface IObserver
    {
        void Update();
    }

    public class MyObserver : IObserver
    {
        private Stock _stock;
        string _name;
        public MyObserver(string name, Stock stock)
        {
            _name = name;
            _stock = stock;
        }
        public void Update()
        {
            System.Console.WriteLine($"My stock {_stock.Symbol} price is {_stock.Price}");
        }

    }
}