namespace src.salary_manager;

internal record Rangepayments
{
    public static Dictionary<string, List<Data>> NewData()
    {
        Dictionary<string, List<Data>> payments = new Dictionary<string, List<Data>>
        {
            {
                "Week",
                [
                    new Data("00:01", "09:00", 25.0),
                    new Data("09:01", "18:00", 15.0),
                    new Data("18:01", "23:00", 20.0),
                ]
            },
            {
                "Weekend",
                [
                    new Data("00:01", "09:00", 30.0),
                    new Data("09:01", "18:00", 20.0),
                    new Data("18:01", "23:00", 25.0)
                ]
            },
        };
        return payments;
    }
}