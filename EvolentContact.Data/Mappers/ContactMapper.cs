using EvolentContact.Common.Enum;
using EvolentContact.Common.Models;
using EvolentContact.Data.Entities;

namespace EvolentContact.Data.Mapper
{
    public class ContactMapper
    {
        public static ContactResponseModel Map(Contact contact)
        {
            ContactStatus status;
            Enum.TryParse(contact.Status, out status);

            return new ContactResponseModel()
            {
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Id = contact.Id,
                PhoneNumber = contact.PhoneNumber,
                Status = status.ToString(),
            };
        }
    }
}
