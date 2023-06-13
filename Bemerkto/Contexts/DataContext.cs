using Bemerkto.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bemerkto.Contexts;

public class DataContext : IdentityDbContext<UserEntity>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    //Adress & User
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }


    //Products
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }

    // ContactForm
    public DbSet<ContactFormEntity> ContactForms { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole {
                Id = "6b7ff063-1eb5-4473-bb12-edb4f51582f2",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },

            new IdentityRole
            {
                Id = "2317d0cd-8313-4016-a08d-5545294a2595",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });

        var passwordHasher = new PasswordHasher<UserEntity>();
        var userEntity = new UserEntity
        {
            Id = "4761c5ad-34df-4670-bf4f-9ef40cf5b656",
            UserName = "admin@domain.com",
            NormalizedUserName = "ADMIN@DOMAIN.COM",
            Email = "admin@domain.com",
            NormalizedEmail = "ADMIN@DOMAIN.COM",
            ConcurrencyStamp = Guid.NewGuid().ToString(),
        };
        userEntity.PasswordHash = passwordHasher.HashPassword(userEntity, "Bytmig123!");
        builder.Entity<UserEntity>().HasData(userEntity);


        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = userEntity.Id,
            RoleId = "6b7ff063-1eb5-4473-bb12-edb4f51582f2"
        });


        //Tags & Products
        builder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, TagName = "new" },
            new TagEntity { Id = 2, TagName = "featured" },
            new TagEntity { Id = 3, TagName = "popular" }
        );

        builder.Entity<ProductEntity>().HasData(
            new ProductEntity { Id = 1, Title = "", Price = 519, ImageUrl = "", Description = ""}
        );

        builder.Entity<ProductTagEntity>().HasData(
            new ProductTagEntity { ProductId = 1, TagId = 1 }
        );
    }
}
