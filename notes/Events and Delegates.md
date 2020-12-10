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


## Delegates for events

A convention in C# for writing delegates for events is that the delegate type takes two arguments:

```cs
public delegate void GradeAddedDelegate(object sender, EventArgs args);
```

You might want to define this in a separate file since it is a new type and technically, new types should go in their own files.

You then want to add a field (a class variable) of that type to the class where you want to use it.  There is the 'event' keyword to use here:

```cs
public event GradeAddedDelegate GradeAdded;
```

It does something to make things safer.  It means you can only use += or -= when working with this field outside of the class itself.  The reason is that because multiple different parts of code might be using that event, so there could be different methods added from different parts of the code, all of which need to run.  If you allow full access, then any one part of the code could assign a null value (for instance) and wipe out the other methods added from elsewhere in the program.

Think of this field as a container for multiple methods that will run? So when it's null, that means no methods have been added. Hence, when you call it:

```cs
//This code comes up after a grade is added.
if (GradeAdded != null)
{   
    //The `this` keyword is passing the type (or class) the method is being called by.
    GradeAdded(this, new EventArgs());
}
```

Raising the event is invoking the delegate, handling the event is adding a method to the delegate.

So now you got the delegate type defined, you've got a field in the `Book` class to hold this type and you're invoking it (calling its methods) at the appropriate time.  At this stage, GradeAdded will just be null so nothing will happen, but there is a structure in place to use when the book class is used in the program.

So, when you want to write some code which will happen when a grade is added e.g. this code in the main method for example:

```cs
static void OnGradeAdded(object sender, EventArgs e)
{
    Console.WriteLine("A grade was added.");
}
```

You can then call the public field from the instance of book and add this new method to it.  This method will then be called whenever a grade is added.

```cs
Book book = new Book("Mike");
book.GradeAdded += OnGradeAdded;
```

ASP.net core doesn't really use events, however windows forms type software uses a lot of events.