namespace src.salary_manager;


internal record Data
{
    public string StartRange;
    public string EndRange;
    public Double Payment;

    public Data(string StartRange, string EndRange, Double Payment)
    {
        this.StartRange = StartRange;
        this.EndRange = EndRange;
        this.Payment = Payment;
    }
}