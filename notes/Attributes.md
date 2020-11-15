## Attributes

These are little bits of data that you attach to a symbol that follows it.

In XUnit, it looks for methods based on their attribute.  For methods with the `[Fact]` attribute, these are treated as tests e.g. something that has to pass or fail.

```cs
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //code
    }
}
```