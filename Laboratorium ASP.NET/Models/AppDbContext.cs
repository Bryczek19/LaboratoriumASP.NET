using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Laboratorium_ASP.NET.Models;

public class AppDbContext:DbContext
{
    public DbSet<ContactEntity> Contacts
    {
        get;
        set;
    }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source=d:\\contacts.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Rafał",
                LastName = "Ogórek",
                PhoneNumber = "983747123",
                BirthDate = new DateTime(2003, 9, 8),
                Email = "konrad.b@wsei.edu.pl",
                Created = DateTime.Now,
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Rafał ",
                LastName = "Ogórek2",
                PhoneNumber = "12353212",
                BirthDate = new DateTime(1950, 1, 7),
                Email = "karol@wsei.edu.pl",
                Created = DateTime.Now,
            }
        );
    }
}
