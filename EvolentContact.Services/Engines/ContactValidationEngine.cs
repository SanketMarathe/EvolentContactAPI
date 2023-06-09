using EvolentContact.Common;
using EvolentContact.Common.Constants;
using EvolentContact.Common.Models;
using EvolentContact.Services.Services.Interfaces;
using System.Text.RegularExpressions;

namespace EvolentContact.Services.Engines
{
    public class ContactValidationEngine
    {
        private readonly IContactService _contactService;
        public ContactValidationEngine(IContactService contactService)
        {
            _contactService = contactService;
        }

        public static BaseResponse ValidateContact(ContactRequestModel contactModel)
        {
            var result = new BaseResponse()
            {
                Errors = new List<string>()
            };

            #region Validate the input

            if (contactModel == null)
            {
                result.Errors.Add(MessageConstant.REQUEST_IS_NULL);
                return result;
            }

            if (string.IsNullOrEmpty(contactModel.FirstName))
            {
                result.Errors.Add(MessageConstant.FIRST_NAME_EMPTY);
            }

            if (string.IsNullOrEmpty(contactModel.LastName))
            {
                result.Errors.Add(MessageConstant.LAST_NAME_EMPTY);
            }

            if (string.IsNullOrEmpty(contactModel.Email))
            {
                result.Errors.Add(MessageConstant.EMAIL_EMPTY);
            }

            if (string.IsNullOrEmpty(contactModel.PhoneNumber))
            {
                result.Errors.Add(MessageConstant.PHONE_NUMBER_EMPTY);
            }

            //Validate Email
            if (!Regex.IsMatch(contactModel.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                result.Errors.Add(MessageConstant.EMAIL_IS_NOT_VALID );
            }

            //Validate Phone Number
            if (!Regex.IsMatch(contactModel.PhoneNumber, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", RegexOptions.IgnoreCase))
            {
                result.Errors.Add(MessageConstant.PHONE_IS_NOT_VALID );
            }

            return result;

            #endregion
        }
    }
}
