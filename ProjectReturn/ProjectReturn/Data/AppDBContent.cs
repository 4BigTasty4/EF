using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectReturn.Data.Model;

namespace ProjectReturn.Data;

public class AppDBContent : IdentityDbContext<AppUser>
{
	public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
	{

	}

    public DbSet<Car> Car { get; set; }
	public DbSet<Category> Category { get; set; }
	public DbSet<ShopCartItem> ShopCartItem { get; set; }
	public DbSet<AppUser> AppUser { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
	
}
