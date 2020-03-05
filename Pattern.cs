using System;
using System.Collections.Generic;

namespace Observer
{
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void Attach(Observer obs)
        {
            observers.Add(obs);
        }
        public void Detach(Observer obs)
        {
            observers.Remove(obs);
        }
        public void Notify()
        {
            foreach (Observer ob in observers)
            {
                ob.Update();
            }
        }
    }
    public class ConcreteSubject : Subject
    {
        public string SubjectState { get; set; }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }
    public class ConcreteObserver : Observer
    {
        private string _name;
        public ConcreteSubject _subject { get; set; }
        public string ObserverState { get; set; }

        public ConcreteObserver(ConcreteSubject sub, string name)
        {
            ObserverState = sub.SubjectState;          
            _name = name;
        }
        public override void Update()
        {
            ObserverState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}", _name, ObserverState);
        }
    }
}