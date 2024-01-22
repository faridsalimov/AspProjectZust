using AspProjectZust.Core.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Entities.Entity
{
    public class CustomIdentityUser : IdentityUser, IEntity
    {
        public CustomIdentityUser()
        {
            Friends = new List<Friend>();
            Posts = new List<Post>();
            FriendRequests = new List<FriendRequest>();
            Chats = new List<Chat>();
            Notifications = new List<Notification>();
        }

        public int LikeCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public bool IsOnline { get; set; }
        public bool IsFriend { get; set; }
        public bool HasRequestPending { get; set; }
        public string? ImageUrl { get; set; } = "no-profile.png";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BackUpEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Occupation { get; set; }
        public string? Gender { get; set; }
        public string? RelationStatus { get; set; }
        public string? BloodGroup { get; set; }
        public string? Language { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }

        public virtual ICollection<Friend>? Friends { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual ICollection<FriendRequest>? FriendRequests { get; set; }
        public virtual ICollection<Chat>? Chats { get; set; }
        //[NotMapped]
        public virtual ICollection<Notification>? Notifications { get; set; }

    }
}
