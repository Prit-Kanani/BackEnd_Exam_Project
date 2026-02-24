using Backend_Exam_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Users> User { get; set; }
    public DbSet<Roles> Role { get; set; }
    public DbSet<Tickets> Ticket { get; set; }
    public DbSet<TicketComments> TicketComment { get; set; }
    public DbSet<TicketStatusLogs> TicketStatusLog { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureRoles(modelBuilder);
        ConfigureUsers(modelBuilder);
        ConfigureTickets(modelBuilder);
        ConfigureTicketComments(modelBuilder);
        ConfigureTicketStatusLogs(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
    private static void ConfigureRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Roles>(b =>
        {

            b.Property(r => r.RoleName)
             .HasConversion<string>()
             .HasMaxLength(20)
             .IsRequired();

            b.ToTable(bi => bi.HasCheckConstraint("CK_Roles_RoleName",
                "RoleName IN ('Manager','Support','User')"));
        });
    }
    private static void ConfigureUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(b =>
        {
            b.Property(r => r.UserName)
                .HasMaxLength(255)
                .IsRequired();

            b.Property(r => r.Email)
                .HasMaxLength(255)
                .IsRequired();

            b.Property(r => r.Password)
                .HasMaxLength(555)
                .IsRequired();

            b.HasOne(u => u.Roles)
             .WithMany()
             .HasForeignKey(u => u.RoleID)
             .OnDelete(DeleteBehavior.NoAction);
        });
    }
    private static void ConfigureTickets(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tickets>(b =>
        {
            b.Property(r => r.Title)
             .HasMaxLength(255)
             .IsRequired();

            b.Property(r => r.Status)
             .HasConversion<string>()
             .HasMaxLength(20)
             .IsRequired()
             .HasDefaultValue("Open");

            b.Property(r => r.Priority)
             .HasConversion<string>()
             .HasMaxLength(20)
             .IsRequired()
             .HasDefaultValue("Medium");

            b.ToTable(bi => bi.HasCheckConstraint("CK_Tickets_Status",
                "Status IN ('Open','In Progress','Resolved', 'Closed')"));

            b.ToTable(bi => bi.HasCheckConstraint("CK_Tickets_Priority",
                "Priority IN ('Low','Medium','High')"));

            b.HasOne(u => u.CreatedByUser)
             .WithMany()
             .HasForeignKey(u => u.CreatedBy)
             .OnDelete(DeleteBehavior.NoAction);

            b.HasOne(u => u.AssignedUser)
             .WithMany()
             .HasForeignKey(u => u.AssignedTo)
             .OnDelete(DeleteBehavior.NoAction);
        });
    }
    private static void ConfigureTicketComments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketComments>(b =>
        {
            b.Property(r => r.Comment)
             .IsRequired();

            b.HasOne(u => u.Users)
             .WithMany()
             .HasForeignKey(u => u.CommentedByID)
             .OnDelete(DeleteBehavior.NoAction);

            b.HasOne(u => u.Tickets)
             .WithMany()
             .HasForeignKey(u => u.TicktID)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
    private static void ConfigureTicketStatusLogs(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketStatusLogs>(b =>
        {
            b.ToTable(bi => bi.HasCheckConstraint("CK_TicketStatusLogs_OldStatus",
                "OldStatus IN ('Open','In Progress','Resolved', 'Closed')"));

            b.ToTable(bi => bi.HasCheckConstraint("CK_TicketStatusLogs_NewStatus",
                "NewStatus IN ('Open','In Progress','Resolved', 'Closed')"));

            b.HasOne(u => u.Users)
             .WithMany()
             .HasForeignKey(u => u.ChangedByID)
             .OnDelete(DeleteBehavior.NoAction);
        });
    }
}