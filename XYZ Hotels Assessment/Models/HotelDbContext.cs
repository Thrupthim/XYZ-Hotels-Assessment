using Microsoft.EntityFrameworkCore;

namespace XYZ_Hotels_Assessment.Models
{
    public class HotelDbContext:DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(h => h.Hotels)
                .WithMany(a => a.Rooms)
                .HasForeignKey(p => p.HotelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
