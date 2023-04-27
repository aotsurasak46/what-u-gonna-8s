using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using System;
using what_u_gonna_eat.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace what_u_gonna_eat.Data;
public class  ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<EaterPost> EaterPost { get; set; }
    public DbSet<DeliverPost> DeliverPosts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<EaterPostAccount> EaterPostAccounts { get; set;}


}
