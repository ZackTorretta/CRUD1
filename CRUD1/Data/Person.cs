using System.ComponentModel.DataAnnotations;

namespace CRUD1.Data
{
    public class Person
    {
        //******possible nullable issue. maybe later.******
        public Guid Id { get; set; } //globally unique. ID are unique
        [Required]
        [StringLength(250, ErrorMessage = "Last name cannot exceed 250 characters.")]
        public string? LastName { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "First name cannot exceed 250 characters.")]
        public string? FirstName { get; set; }

        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string? PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;


    }
}
