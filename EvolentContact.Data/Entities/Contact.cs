using System.ComponentModel.DataAnnotations;

namespace EvolentContact.Data.Entities
{
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Contact Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Contact First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Contact Last Name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Contact Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Contact Phone Number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contact Status
        /// </summary>
        [Required]
        public string Status { get; set; }
    }
}
