using Microsoft.EntityFrameworkCore;
using TrackForge.Models;

namespace TrackForge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
