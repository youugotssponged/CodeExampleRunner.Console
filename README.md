# CodeExampleRunner.Console
A stone throw example runner to allow you to play with C# Code without the mess that comes with having to edit/re-edit the main method and other jazz

# How to Use

1. Use the IExample interface from the ExampleRunner and place it on your code example class that you would like to run
```csharp
public interface IExample
{
    public bool Skip { get; set; } // Used to skip the example at runtime
    public void RunExample(); // Method that is invoked to run the example - your example's "main" method per say
}
```


2. Inside your Console Project's Main method use the code below

```csharp
public static void Main()
{
    ExampleRunner runner = new();
    runner.ScanAndRunExamplesInCurrentAssembly();
}
```
