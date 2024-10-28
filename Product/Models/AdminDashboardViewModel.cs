namespace Product.Models
{
    public class AdminDashboardViewModel
    {
        public int FoodCount { get; set; }
        public int UserCount { get; set; }
        public List<Food> Foods { get; set; }
        public List<User> Users { get; set; }
        public string[] FoodNames { get; set; }
        public decimal[] Prices { get; set; }
    }
}
