## References

There may be a way to add references using vscode but to do it with the dotnot cli, you just use the following in the project folder you want to add the reference into:

```cli
dotnet add reference <PROJECT PATH>
```

To reference another dotnet project, you need to reference the .csproj file from that project. 

You will also need a `using` statement to bring in the namespace.  You won't need to do this for example when unit testing, as you will be working in a namespace below the main project namespace e.g. `GradeBook.Tests` from `GradeBook`.

 As long as the classes in it are public, they will then be accesible from your current project.  Any classes referenced within another class also need to be at least as accesible.