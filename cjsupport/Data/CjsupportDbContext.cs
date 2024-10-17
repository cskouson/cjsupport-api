using Microsoft.EntityFrameworkCore;
using cjsupport.Data.Entities;

namespace cjsupport.Data
{
    public class CjsupportDbContext : DbContext
    {
        public CjsupportDbContext(DbContextOptions<CjsupportDbContext> options) : base(options) { }

        public DbSet<SupportTicketEntity> SupportTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("en_US.UTF-8")
                .HasPostgresExtension("extensions", "pg_repack")
                .HasPostgresExtension("extensions", "pg_stat_statements");


            modelBuilder.Entity<SupportTicketEntity>(entity =>
            {
                entity.ToTable("support_ticket", "support");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email");
                entity.Property(e => e.Description) 
                    .HasColumnName("description");
                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date");
                entity.Property(e => e.IsComplete)
                    .HasColumnName("is_complete");
            });          
        }
    }
}
