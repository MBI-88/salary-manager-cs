
namespace src.salary_manager;


internal class SalaryManager : ISalaryManager
{
    private readonly Dictionary<string, double> ToPay = [];


    public Dictionary<string, double> ProcessData(List<string> employees)
    {
        
        foreach (string employee in employees)
        {
            string name = employee.Split("=")[0];
            string[] range = employee.Split("=")[1].Split(",");
            ToPay[name] = 0;

            foreach (string r in range)
            {
                string day = r[0..2];
                DateTime StartRange = Formater(r.Split("-")[0][2..]);
                DateTime EndRange = Formater(r.Split("-")[1]);

                switch (day)
                {
                    case "MO":
                    case "TU":
                    case "WE":
                    case "TH":
                    case "FR":
                        Operations(Rangepayments.NewData()["Week"], name, StartRange, EndRange);
                        break;
                    case "SA":
                    case "SU":
                        Operations(Rangepayments.NewData()["Weekend"], name, StartRange, EndRange);
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

    private DateTime Formater(string hours) => DateTime.Parse(hours);

    private void Operations(List<Data> payrange, string name, DateTime start, DateTime end)
    {
        for (int i = 0; i < payrange.Count; i++)
        {
            if (start.CompareTo(Formater(payrange[i].EndRange)) > 0)
            {
                continue;
            }
            else if (
                start.CompareTo(Formater(payrange[i].StartRange)) > -1
                &&
                start.CompareTo(Formater(payrange[i].EndRange)) < 1
                &&
                end.CompareTo(Formater(payrange[i].EndRange)) < 1
                )
            {
                ToPay[name] += payrange[i].Payment * end.Subtract(start).TotalHours;
            }
            else if (
                    start.CompareTo(Formater(payrange[i].StartRange)) > -1
                    &&
                    start.CompareTo(Formater(payrange[i].EndRange)) < 1
                    &&
                    end.CompareTo(Formater(payrange[i].EndRange)) > 0
             )
            {
                ToPay[name] += payrange[i].Payment * Formater(payrange[i].EndRange).Subtract(start).TotalHours;

                for (int t = i + 1; t < payrange.Count; t++)
                {
                    if (
                        end.CompareTo(Formater(payrange[t].StartRange)) > -1
                        &&
                        end.CompareTo(Formater(payrange[t].EndRange)) < 1
                        )
                    {

                        ToPay[name] += payrange[t].Payment * end.Subtract(Formater(payrange[t].StartRange)).TotalHours;

                    }
                    else if (end.CompareTo(Formater(payrange[t].EndRange)) > 0)
                    {
                        ToPay[name] += payrange[t].Payment * Formater(payrange[t].EndRange).Subtract(Formater(payrange[t].StartRange)).TotalHours;
                    }
                }
            }
        }

    }
}