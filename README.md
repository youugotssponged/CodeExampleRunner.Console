# CodeExampleRunner.Console
A stone throw example runner to allow you to play with C# Code without the mess that comes with having to edit/re-edit the main method and other jazz

Not the prettiest thing but will definitely help aid that late night research/code practise when playing around with new concepts that don't need dedicated projects. 

This runner allows you to additively add code to be ran via the console
- complexity of O(N) (per class)

![image](https://user-images.githubusercontent.com/11492379/169673743-8e8c45f1-9f96-4d4d-b3db-052c2ac5a86b.png)


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
