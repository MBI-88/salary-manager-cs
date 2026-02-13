using src.salary_manager;

namespace SalaryManager.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        List<string> source = [
            "JOSE=MO08:00-19:00",
                "JUAN=TH12:00-17:00,FR09:01-16:00",
                "ANA=SA09:00-13:00,MO08:10-16:00"
        ];
        Dictionary<string, double> tests = new Dictionary<string, double>
        {

            {
                "JOSE", 179.0
            },
            {
                "JUAN", 179.0
            },
            {
                "ANA", 209.0
            }
        };
        var manager = Factory.NewSalaryManager();
        var result = manager.ProcessData(source);

        foreach (string key in result.Keys)
        {
            if (result[key] != tests[key])
            {
                Console.WriteLine($"Output {result[key]} expected {tests[key]}");
            }
        }
    }
}

internal class TestClassAttribute : Attribute
{
}

internal class TestMethodAttribute : Attribute
{
}