using EvolentContact.Common.Models;
using EvolentContact.Data.Mapper;
using EvolentContact.Services.Repositories.Interfaces;
using EvolentContact.Services.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace EvolentContact.Services.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMemoryCache _memoryCache;

        public ContactService(IContactRepository contactRepository,
                              IMemoryCache memoryCache)
        {
            _contactRepository = contactRepository;
            _memoryCache = memoryCache;
        }

        public async Task<ContactResponseModel> CreateContact(ContactRequestModel model)
        {
            return await _contactRepository.CreateContact(model);
        }

        public List<ContactResponseModel> GetAllContacts(int page, int pageSize)
        {
            var contacts = _memoryCache.Get<List<ContactResponseModel>>("contacts");
            if (contacts is not null) return contacts;

            contacts = _contactRepository.GetAllContacts(page, pageSize);
            _memoryCache.Set("contacts", contacts, TimeSpan.FromSeconds(20));
            return contacts;
        }

        public async Task<ContactResponseModel> GetContactById(Guid contactId)
        {
            var contactModel = _memoryCache.Get<ContactResponseModel>(contactId);
            if (contactModel is not null) return contactModel;

            var contact = await _contactRepository.GetContactById(contactId);
            var model = ContactMapper.Map(contact);
            _memoryCache.Set(contactId, model, TimeSpan.FromSeconds(20));
            return model;
        }

        public async Task<ContactResponseModel> UpdateContact(Guid contactId, ContactRequestModel model)
        {
            return await _contactRepository.UpdateContact(contactId, model);
        }

        public async Task<ContactResponseModel> DeleteContact(Guid contactId)
        {
            var contact = await _contactRepository.DeleteContact(contactId);
            var model = ContactMapper.Map(contact);
            return model;
        }

        public async Task<bool> IsEmailExist(Guid contactId, string email)
        {
            return await _contactRepository.IsEmailExist(contactId, email);
        }

        public async Task<bool> IsPhoneNumberExist(Guid contactId, string phoneNumber)
        {
            return await _contactRepository.IsPhoneNumberExist(contactId, phoneNumber);
        }
    }
}
