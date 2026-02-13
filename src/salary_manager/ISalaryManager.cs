namespace src.salary_manager;



public interface ISalaryManager
{
    Dictionary<string, double> ProcessData(List<String> employees);
    List<string> LoadFile(string path);
}