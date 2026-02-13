namespace src.salary_manager;



public class Factory
{
    public static ISalaryManager NewSalaryManager()
    {
        return new SalaryManager();
    }
}