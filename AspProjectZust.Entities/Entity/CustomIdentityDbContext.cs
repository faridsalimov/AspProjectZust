using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Entities.Entity
{
    public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options)
          : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserCity> UserCities { get; set; }
        public DbSet<UserCountry> UserCountries { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserRelationStatus> UserRelationStatus { get; set; }
        public DbSet<UserGender> UserGenders { get; set; }
        public DbSet<UserOccupation> UserOccupations { get; set; }
        public DbSet<UserBloodGroup> UserBloodGroups { get; set; }

        public CustomIdentityDbContext()
        {

        }
    }
}
