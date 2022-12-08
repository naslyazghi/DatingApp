using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")] // This will specify that our DB table will eb named Photos and EF will take of this and do the maping between our entity and the db table
    public class Photo
    {
        public int Id { get; set; } 
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int AppUserId { get; set; } // This is to force EF to create a relation between user and photo and make the photo field has to have a appUserId onDB
        public AppUser AppUser { get; set; } // This is to force EF to create a relation between user and photo and make the photo field has to have a appUserId on DB
    }
}