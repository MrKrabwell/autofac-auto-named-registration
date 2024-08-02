namespace AutofacTesting;

public class MyServiceA : IMyService
{
    #region Public Methods and Operators

    public void DoSomething()
    {
        Console.WriteLine($"{nameof(MyServiceA)} is doing something");
    }

    public string GetName()
    {
        return nameof(MyServiceA);
    }

    #endregion
}