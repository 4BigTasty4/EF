using ProjectReturn.Data.Model;

namespace ProjectReturn.ViewModels;

public class AdminDashboardViewModel
{
    public List<AppUser> AppUsers { get; set; }
    public List<Order> Orders { get; set; }
    public List<Car> Cars { get; set; }
    public List<Category> Categories { get; set; }
}

