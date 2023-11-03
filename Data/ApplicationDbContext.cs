using Microsoft.EntityFrameworkCore;
using SimpleTaskAPI.Entities.Models;

namespace SimpleTaskAPI.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    

    public DbSet<TaskModel> TaskEntity { get; set; }
}
