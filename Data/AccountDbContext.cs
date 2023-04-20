using Microsoft.EntityFrameworkCore;
using what_u_gonna_eat.Models;

namespace what_u_gonna_eat.Data;
public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }

    public DbSet<Account> Account { get; set; }

    public DbSet<EaterPost> EaterPosts { get; set; } = default!;




}
