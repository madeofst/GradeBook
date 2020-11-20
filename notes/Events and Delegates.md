# Events and Delegates

* Events are not in style with server frameworks.
* Events are hard to understand.
* Events are and have been popular in forms and desktop programming.

Before you can understand events, you need to understand delegates.

## Delegates

OK, so these seem a bit convoluted.  I'm sure they have a use, but I'm struggling to see it at the moment.

It seems like you want to be able to call a method like:

```cs
string logMessage = "Test log message";
string result;

result = log(logMessage);
```

So, you want to show it simply in line, but you actually want the `log` method to potentially refer to completely different methods, but with the same structure or signature.  So the delegate is a structure for this.  It designates this structure in terms of a new 'type'.  This means you have to write these outside of any class or struct or other type.  So the syntax for creating a delegate is:

```cs
public delegate string WriteLogDelegate(string logMessage);  //the name of the parameter is irrelevant here, the important part is that there is a single parameter of type string and a return type of string.
```

You can then take a method which matches this type (inside a class or whatever):

```cs
string ReturnMessage(string messsage)
{
    return message;
}
```

The name of this method, and the content can be anything.

To use this method in the form of the delegate, you then invoke the delegate

```cs
public delegate string WriteLogDelegate(string logMessage);

public someClass
{
    public void someMethod()
    {
        WriteLogDelegate log;
        log = new WriteLogDelegate(ReturnMessage); //This is the long hand notation.
        log = ReturnMessage;    //This is the short-hand notation.

        //Now you can actually do what you orignally wanted
        result = log(logMessage);
    }

    string ReturnMessage(string messsage)
    {
        return "Logged.";
    }
}
```

### Multi-cast delegates

The next interesting step is that you when you invoke the delegate, you can add multiple methods using `+=`.  

```cs
class DelegateDemo
{
    private int count = 0;
    public delegate string WriteALogMessage(string msg);

    public string JustCount(string message)
    {
        count++;
        return null;
    }
    
    public string WriteLogAndCount(string message)
    {
        count++;
        return $"Message {message} logged and count is {count}.";
    }

    public void DoAllDelegateActions(string message)
    {
        WriteALogMessage log;
        log = JustCount;
        log += WriteLogAndCount;
        Console.WriteLine(log(message));
    }
}
```

In the above case, when you call `DoAllDelegateActions` it runs both `JustCount` and `WriteLogAndCount`.  Sidenote - it only writes to console the return value of the last method added to the delegate invocation.  Not 100% on why this is, but I suspect it wouldn't make sense to able to return multiple values of the same type in a single variable (or something)?


## Events

