using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Laboratorium_ASP.NET.Models;

public class AppDbContext
{
    public DbSet<ContactEntity> Contacts
    {
        get;
        set;
    }
    private string DbPath { get; set; }
    public AppObContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
        
        
    }

    protected override void Onfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString $"Data source=-{DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                
                
                
                
                
                
                
                ):
        
        
        
        
    }
}
