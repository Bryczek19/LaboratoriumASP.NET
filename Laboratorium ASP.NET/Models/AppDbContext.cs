using Microsoft.AspNetCore.Identity;
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
    public DbSet<OrganizationEntity> Organizations { get; set; }
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
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OrganizationEntity>().OwnsOne(o => o.Address).HasData(
            new {OrganizationEntityId = 1, City = "Kraków", Street = "św. Filipa"},
            new {OrganizationEntityId = 2, City = "Warszawa", Street = "Wesoła"}
        );

        modelBuilder.Entity<ContactEntity>().HasOne<OrganizationEntity>(c => c.Organizations).WithMany(o => o.Contacts)
            .HasForeignKey(o => o.OrganizationId);
        

        modelBuilder.Entity<OrganizationEntity>().HasData(
            new OrganizationEntity()
            {
                Id = 1,
                Regon = "7126311",
                Nip = "12321312",
                Name = "WSEI",
            },
            new OrganizationEntity()
            {
                Id = 2,
                Regon = "111111",
                Nip = "123232131312",
                Name = "UJ",
            }
        );
        
        
        
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Rafał",
                LastName = "Kowalski",
                PhoneNumber = "123456789",
                BirthDate = new DateTime(2000, 10, 10),
                Email = "jakub@wsei.edu.pl",
                Created = DateTime.Now,
                OrganizationId = 1
            },
        new ContactEntity()
            {
                Id = 2,
                FirstName = "Rafał",
                LastName = "Kowalski",
                PhoneNumber = "132556789",
                BirthDate = new DateTime(1990, 11, 15),
                Email = "karol@wsei.edu.pl",
                Created = DateTime.Now,
                OrganizationId = 2
            }
        );

        string adminId;
        var admin = new IdentityUser()
        {
          Id= adminId,
          UserName = "Adam",
          NormalizedUserName = "ADAM",
          Email = "adam@wsei.edu.pl",
          NormalizedEmail = "ADAM@WSEI.EDU.PL",
          EmailConfirmed = true

        };
        var user = new IdentityUser()
        {
            Id= USER_ID,
            UserName = "Ewa",
            NormalizedUserName = "EWA",
            Email = "ewa@wsei.edu.pl",
            NormalizedEmail = "EWA@WSEI.EDU.PL",
            EmailConfirmed = true
            
        };
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = hasher.HashPassword(admin, password: "1234!");
        user.PasswordHash = hasher.HashPassword(user, password: "abcd!");

        modelBuilder.Entity<IdentityUser>()
            .HasData(admin, user);
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminId
                    UserID = ADMIN_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ID
                    USER_ID = USER_ID
                }
            );

    }
}

public class OrganizationEntity
{
    public OrganizationEntity(IEnumerable<ContactEntity>? contacts, int id, string nip, string name)
    {
        Contacts = contacts;
        Id = id;
        Nip = nip;
        Name = name;
    }
    

    public OrganizationEntity()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ContactEntity>? Contacts { get; set; }
    public int Id { get; set; }
    public string Regon { get; set; }
    public string Nip { get; set; }
    public string Name { get; set; }
    public object Address { get; set; }
}
