namespace Core.Models.Entities.Dashboard;

public class DashboardResponseModel
{
    public int ProductCount { get; set; }
    public int UserCount { get; set; }
    public int OrderCount { get; set; }
    public int CartCount { get; set; }
    public List<int> MonthlySales { get; set; }
}