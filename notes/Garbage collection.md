## Garbage collector

You don't need to clean up after yourself.  It run's garbage collection after it knows you aren't referencing things any more (e.g. at the end of the method).

You can probably take advantage of this by paying attention to where variables exist.  Global variables are perhaps not a good idea (in most cases) - if Casey Muratori is right about it, and the same rules apply as in C#.