using src.salary_manager;
using tests;


public class Program
{
    public static void Main(string[] args)
    {
        var manager = Factory.NewSalaryManager();
        var result = manager.ProcessData(manager.LoadFile(args[1]));
        Console.WriteLine(string.Join(", ", result.Select (kv => $"{kv.Key}:{kv.Value}")));


        //Console.WriteLine("Test");
        //SalaryManagerTest.Test();
    }
}