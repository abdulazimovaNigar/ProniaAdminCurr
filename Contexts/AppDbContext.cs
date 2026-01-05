using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ProniaAdmin.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Shipping> Shippings { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categorys { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}
