
namespace src.salary_manager;


internal class SalaryManager : ISalaryManager
{
    private readonly Dictionary<string, double> ToPay = [];


    public Dictionary<string, double> ProcessData(List<string> employees)
    {
        var payments = Rangepayments.NewData();

        foreach (string employee in employees)
        {
            string name = employee.Split("=")[0];
            string[] range = employee.Split("=")[1].Split(",");

            for (int i = 0; i < range.Length; i++)
            {
                string day = range[i][0..2];
                DateTime StartRange = Formater(range[i].Split("-")[0][2..]);
                DateTime EndRange = Formater(range[i].Split("-")[1]);

                switch (day)
                {
                    case "MO":
                    case "TU":
                    case "WE":
                    case "TH":
                    case "FR":
                        Operations(payments["Week"], name, StartRange, EndRange);
                        break;
                    case "SA":
                    case "SU":
                        Operations(payments["Weekend"], name, StartRange, EndRange);
                        break;
                }

            }
        }


        return ToPay;
    }

    public List<string> LoadFile(string path)
    {
        string[] content;
        try
        {
            content = File.ReadAllLines(path);
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            return [];
        }

        return [.. content];
    }

    private DateTime Formater(string hours)
    {
        return DateTime.Parse(hours);
    }

    private void Operations(List<Data> payrange, string name, DateTime start, DateTime end)
    {
        ToPay[name] = 0.0;

        for (int i = 0; i < payrange.Capacity; i++)
        {
            if (start.CompareTo(Formater(payrange[i].EndRange)) > 0)
            {
                continue;
            }
            else if (
                start.CompareTo(Formater(payrange[i].StartRange)) >= 0
                &&
                start.CompareTo(Formater(payrange[i].EndRange)) <= 0
                &&
                end.CompareTo(Formater(payrange[i].EndRange)) <= 0
                )
            {
                ToPay[name] += payrange[i].Payment * end.Subtract(start).Hours;
            }
            else if (
                    start.CompareTo(Formater(payrange[i].StartRange)) >= 0
                    &&
                    start.CompareTo(Formater(payrange[i].EndRange)) <= 0
                    &&
                    end.CompareTo(Formater(payrange[i].EndRange)) > 0
             )
            {
                ToPay[name] += payrange[i].Payment * Formater(payrange[i].EndRange).Subtract(start).Hours;

                for (int t = i + 1; t < payrange.Count; t++)
                {
                    if (
                        end.CompareTo(Formater(payrange[t].StartRange)) >= 0
                        &&
                        end.CompareTo(Formater(payrange[t].EndRange)) <= 0
                        )
                    {

                        ToPay[name] += payrange[t].Payment * end.Subtract(Formater(payrange[t].StartRange)).Hours;

                    }
                    else if (end.CompareTo(Formater(payrange[t].StartRange)) > 0
                              &&
                              end.CompareTo(Formater(payrange[t].EndRange)) > 0
                            )
                    {

                        ToPay[name] += payrange[t].Payment * Formater(payrange[t].EndRange).Subtract(Formater(payrange[t].StartRange)).Hours;


                    }
                }
            }
        }

    }
}