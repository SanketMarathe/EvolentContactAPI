using EvolentContact.Common.Models;
using EvolentContact.Data.Entities;

namespace EvolentContact.Services.Repositories.Interfaces
{
    public interface IContactRepository
    {
        /// <summary>
        /// Create Contact
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ContactResponseModel</returns>
        Task<ContactResponseModel> CreateContact(ContactRequestModel model);

        /// <summary>
        /// Update Contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="model"></param>
        /// <returns>ContactResponseModel</returns>
        Task<ContactResponseModel> UpdateContact(Guid contactId, ContactRequestModel model);

        /// <summary>
        /// Get All Contacts
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>List<ContactModel></returns>
        List<ContactResponseModel> GetAllContacts(int page, int pageSize);

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns>Contact</returns>
        Task<Contact> DeleteContact(Guid contactId);

        /// <summary>
        /// Get Contact By Id
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns>Contact</returns>
        Task<Contact> GetContactById(Guid contactId);

        /// <summary>
        /// Check Is Email Exist!
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="email"></param>
        /// <returns>bool</returns>
        Task<bool> IsEmailExist(Guid contactId, string email);

        /// <summary>
        /// Check Is Phone Number Exist!
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="phoneNumber"></param>
        /// <returns>bool</returns>
        Task<bool> IsPhoneNumberExist(Guid contactId, string phoneNumber);
    }
}
