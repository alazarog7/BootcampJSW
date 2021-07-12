using System;

namespace Events
{
    //public delegate void Notify(object a , EventArgs b);
    public delegate void Notify<T>( T status);

    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new();

            Subscriber subscriber1 = new();
            Subscriber subscriber2 = new();

            publisher.NotifyEvent += subscriber1.HandleEvent;
            publisher.NotifyEvent += subscriber2.HandleEvent;

            publisher.DoSomething();

        }
    }

    public class CustomEventArgs
    {
        public DateTime TimeStamp { get; set; }

        public bool Status { get; set; }
    }

    class Publisher
    {
        public event Notify<CustomEventArgs> NotifyEvent;

        public void DoSomething()
        {
            Console.WriteLine("Calling backend ...");

            CustomEventArgs customEventArgs = new()
            {
                TimeStamp = new DateTime(2021, 7, 7),
                Status = true
            };
            
            NotifySubscribers(customEventArgs);
        }

        public void NotifySubscribers(CustomEventArgs customEventArgs)
        {
            NotifyEvent?.Invoke(customEventArgs);
        }
    }

    public class Subscriber
    {
        public void HandleEvent(CustomEventArgs args)
        {
            Console.WriteLine($"{args.TimeStamp} {args.Status}");
        }
    }


    //public class ProcessBusinessLogic
    //{
    //    public event Notify ProcessCompleted;
    //}

    //class Publisher
    //{
    //    public event Notify NotifyEvent;

    //    public void DoSomething()
    //    {
    //        Console.WriteLine("Calling backend ...");
    //        NotifySubscribers(EventArgs.Empty);
    //    }

    //    public void NotifySubscribers(EventArgs eventArgs)
    //    {
    //        NotifyEvent?.Invoke(this, eventArgs);
    //    }
    //}


    //class Publisher
    //{
    //    public event Notify NotifyEvent;

    //    public void DoSomething()
    //    {
    //        Console.WriteLine("Calling backend ...");
    //        NotifySubscribers(true);
    //    }

    //    public void NotifySubscribers(bool status)
    //    {
    //        NotifyEvent?.Invoke(status);
    //    }
    //}

    //public class Subscriber
    //{
    //    public void HandleEvent(bool status)
    //    {
    //        Console.WriteLine("Handling Event");
    //    }
    //}


}
