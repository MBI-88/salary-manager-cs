
using Xunit;
using src.salary_manager;

namespace tests;

public class SalaryManagerTest
{
    public static void Test()
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
            Assert.Equal((int)result[key], (int)tests[key]);
        }
    }
}