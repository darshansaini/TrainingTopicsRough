using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Format numbers
        double number = 12345.6789;
        Console.WriteLine("Formatted Number: " + FormatNumber(number));
        Console.WriteLine("Formatted Number (Percentage): " + FormatNumber(number / 100, "P"));
        Console.WriteLine("Formatted Number (Custom): " + FormatNumber(number, "#,##0.00"));


        // Date and Time
        DateTime now = DateTime.Now;
        Console.WriteLine("Current Date and Time: " + now);
        Console.WriteLine("Formatted Date and Time: " + FormatDateTime(now));
        Console.WriteLine("Formatted Date: " + FormatDateTime(now, "yyyy-MM-dd"));
        Console.WriteLine("Formatted Time: " + FormatDateTime(now, "HH:mm:ss"));
        Console.WriteLine("Tomorrow's Date: " + FormatDateTime(now.AddDays(1), "yyyy-MM-dd"));


        // Event and Delegates
        var eventPublisher = new EventPublisher();
        eventPublisher.NumberGenerated += EventSubscriber.NumberGeneratedHandler;
        eventPublisher.GenerateRandomNumber();


        // C# generics
        Console.WriteLine("Generic List Example:");
        var list = new MyList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Console.WriteLine("Items in list:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    // Format numbers
    static string FormatNumber(double number)
    {
        return number.ToString("#,##0.00");
    }
    static string FormatNumber(double number, string format)
    {
        return number.ToString(format);
    }

    // Format Date and Time
    static string FormatDateTime(DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
    static string FormatDateTime(DateTime dateTime, string format)
    {
        return dateTime.ToString(format);
    }
}

// Event and Delegates
public delegate void NumberGeneratedEventHandler(int number);

public class EventPublisher
{
    public event NumberGeneratedEventHandler NumberGenerated;

    public void GenerateRandomNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 100);
        NumberGenerated?.Invoke(randomNumber);
    }
}

public class EventSubscriber
{
    public static void NumberGeneratedHandler(int number)
    {
        Console.WriteLine("Generated Random Number: " + number);
    }
}

// Without generics
public class MyList
{
    private ArrayList items = new ArrayList();

    public void Add(object item)
    {
        items.Add(item);
    }

    public IEnumerator GetEnumerator()
    {
        return items.GetEnumerator();
    }
}

// With generics
public class MyList<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }
}
