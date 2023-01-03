using System.ComponentModel.DataAnnotations;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }    
        public string Country { get; set; } 
        public List<Photo> Photos { get; set; } = new();

        // Those properties for the joint table to support many to many relationship
        public List<UserLike> LikedByUsers { get; set; }
        public List<UserLike> LikedUsers { get; set; }


        //Automapper will automatically reconizes this method since it has the Age property and Get Keyword and mapp the dateOfBirth of AppUser class to Age in the MemberDto class
        // public int GetAge() 
        // {
        //     return DateOfBirth.CalculateAge();
        // }
    }
}