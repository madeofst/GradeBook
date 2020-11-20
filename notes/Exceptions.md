## Exceptions

This is a means of error handling. The keyword `throw` is used like so:

```cs
throw new ArgumentException($"Invalid {nameof(grade)}");
```

When you `throw` something, the idea is for some other piece of code to `catch` or handle it.

```cs
try
{
    double grade = double.Parse(input);
    book.AddGrade(grade);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

In `try`, whenever an exception arises code skips until it reaches a `catch` statement.

In the `catch` statement, you're specifying what kind of exception you're looking for by creating a variable of type exception.  In this case, all exceptions would be caught, you would normally specify a more specific inherited class of exceptions that you want to look at (and maybe check some conditions of it as well?!).

### Stacking catches

You can stack catches for different types of exception in order to handle them differently.

```cs
try
{
    double grade = double.Parse(input);
    book.AddGrade(grade);
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    // This will execute whenever any exception happens (or not!)
}
```
