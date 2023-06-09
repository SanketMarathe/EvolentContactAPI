using EvolentContact.Common.Models;

namespace EvolentContact.Services.Services.Interfaces
{
    public interface IContactService
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
        /// <returns></returns>
        List<ContactResponseModel> GetAllContacts(int page, int pageSize);

        /// <summary>
        /// Get Contact By Id
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<ContactResponseModel> GetContactById(Guid contactId);

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<ContactResponseModel> DeleteContact(Guid contactId);

        /// <summary>
        /// Check Is Email Exist!
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> IsEmailExist(Guid contactId, string email);

        /// <summary>
        /// Check Is Phone Number Exist!
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<bool> IsPhoneNumberExist(Guid contactId, string phoneNumber);
    }
}
