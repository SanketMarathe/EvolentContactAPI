using EvolentContact.Common.Constants;
using EvolentContact.Common.Enum;
using EvolentContact.Common.Models;
using EvolentContact.Data;
using EvolentContact.Data.Entities;
using EvolentContact.Data.Mapper;
using EvolentContact.Data.Pagination;
using EvolentContact.Services.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvolentContact.Services.Repositories.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private EvolentDBContext _context;

        public ContactRepository(EvolentDBContext context)
        {
            _context = context;
        }

        public async Task<ContactResponseModel> CreateContact(ContactRequestModel model)
        {
            var guid = Guid.NewGuid();

            var contact = new Contact()
            {
                Id = guid,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Status = ContactStatus.Active.ToString(),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = guid,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = guid
            };

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return ContactMapper.Map(contact);
        }

        public List<ContactResponseModel> GetAllContacts(int page, int pageSize)
        {
            var contactList = from con in _context.Contacts
                              where con.Status == ContactStatus.Active.ToString()
                              orderby con.UpdatedAt descending
                              select ContactMapper.Map(con);

            return contactList.GetPaged(page, pageSize).Results.ToList();
        }

        public async Task<ContactResponseModel> UpdateContact(Guid contactId, ContactRequestModel model)
        {
            var contact = await GetContactById(contactId);

            if (contact == null)
            {
                throw new Exception(MessageConstant.CONTACT_NOT_FOUND);
            }

            if (await IsEmailExist(contact.Id, model.Email))
            {
                throw new Exception(MessageConstant.EMAIL_ALREADY_EXIST);
            }

            if (await IsPhoneNumberExist(contact.Id, model.PhoneNumber))
            {
                throw new Exception(MessageConstant.PHONE_ALREADY_EXIST);
            }

            contact.FirstName = model.FirstName ?? contact.FirstName;
            contact.LastName = model.LastName ?? contact.LastName;
            contact.Email = model.Email ?? contact.Email;
            contact.PhoneNumber = model.PhoneNumber ?? contact.PhoneNumber;

            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return ContactMapper.Map(contact);
        }

        public async Task<Contact> DeleteContact(Guid contactId)
        {
            var contact = await GetContactById(contactId);

            if (contact == null)
            {
                throw new Exception(MessageConstant.CONTACT_NOT_FOUND);
            }

            contact.Status = ContactStatus.Inactive.ToString();
            contact.UpdatedAt = DateTime.UtcNow;

            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> GetContactById(Guid contactId)
        {
            return await _context.Contacts.FindAsync(contactId);
        }

        public async Task<bool> IsEmailExist(Guid contactId, string email)
        {
            return await _context.Contacts.AnyAsync(x => x.Email.Equals(email) && x.Id != contactId);
        }

        public async Task<bool> IsPhoneNumberExist(Guid contactId, string phoneNumber)
        {
            return await _context.Contacts.AnyAsync(x => x.PhoneNumber.Equals(phoneNumber) && x.Id != contactId);
        }
    }
}
