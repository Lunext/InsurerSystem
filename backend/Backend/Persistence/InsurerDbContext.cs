
using Microsoft.EntityFrameworkCore;
namespace Backend.Shared;


public partial class InsurerDbContext:DbContext
{
    public virtual DbSet<Insurer> Insurers { get; set; } = null!;

    public InsurerDbContext()
    {}

    public InsurerDbContext(DbContextOptions<InsurerDbContext> options)
    :base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Filename=../Insurer.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //This is to round the commission property to just 2 decimal places
        modelBuilder.Entity<Insurer>().Property(e => e.Commission).HasColumnType("DECIMAL(6,2)");

       // modelBuilder.Entity<Insurer>().Property(e => e.Commission).HasColumnType("NUMERIC(18, 9)");



        OnModelCreatingPartial(modelBuilder); 
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 
}
