namespace AutofacTesting;

public class MyServiceB : IMyService
{
    #region Public Methods and Operators

    public void DoSomething()
    {
        Console.WriteLine($"{nameof(MyServiceB)} is doing something");
    }

    public string GetName()
    {
        return nameof(MyServiceB);
    }

    #endregion
}