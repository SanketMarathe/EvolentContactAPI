using System.ComponentModel.DataAnnotations;

namespace EvolentContact.Common.Models
{
    /// <summary>
    /// Evolent Contact Model
    /// </summary>
    public class ContactResponseModel
    {
        /// <summary>
        /// Contact Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Contact First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Contact Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Contact Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contact Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contact Status
        /// </summary>
        public string Status { get; set; }
    }
}
