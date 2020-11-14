## Solution files

These are used by dotnet and visual studio and so on to make building, testing and running easier.

You create an empty solution file with:

```cli
dotnet new sln
```

You would do this at the top level (the same level as your `\src` and `\tests` folders for example).

You then add projects to the solution. This is simply (from the same top level location):

```cli
dotnet sln add src\GradeBook\GradeBook.csproj
dotnet sln add test\GradeBook.Tests\GradeBook.Tests.csproj
```

This now means you can also run `dotnet test` from this same location.
