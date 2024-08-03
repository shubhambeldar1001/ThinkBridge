using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaskOffice> TaskOffices { get; set; }
        //public DbSet<TaskNote> TaskNotes { get; set; }
       // public DbSet<TaskAttachment> TaskAttachments { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskOffice>()
                .HasOne(t => t.AssignedUser)
                .WithMany()
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TaskNote>().HasKey(n => n.NoteId);

            modelBuilder.Entity<TeamMember>()
        .HasKey(tm => tm.TeamMemberId);
        }
    }
}
