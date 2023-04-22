using Microsoft.EntityFrameworkCore;
using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Data;
public class  ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<EaterPost> EaterPosts { get; set; }

    public DbSet<DeliverPost> DeliverPosts { get; set; }
    
}
