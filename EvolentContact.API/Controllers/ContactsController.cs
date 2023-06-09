using EvolentContact.Common;
using EvolentContact.Common.Constants;
using EvolentContact.Common.Models;
using EvolentContact.Services.Engines;
using EvolentContact.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EvolentContact.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogService _logger;

        public ContactsController(IContactService contactService, ILogService logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        /// <summary>
        /// Create Contact
        /// </summary>
        /// <remarks>
        /// Get All Conatcts
        /// </remarks>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateContact([FromBody] ContactRequestModel contactRequestModel)
        {
            var result = ContactValidationEngine.ValidateContact(contactRequestModel);

            try
            {
                #region Validate the input

                if (!result.Success && result?.Errors?.Count > 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                //Check Email
                if (await _contactService.IsEmailExist(Guid.Empty, contactRequestModel.Email))
                {
                    result.Errors.Add(MessageConstant.EMAIL_ALREADY_EXIST);
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                //Check Phone Number
                if (await _contactService.IsPhoneNumberExist(Guid.Empty, contactRequestModel.PhoneNumber))
                {
                    result.Errors.Add(MessageConstant.PHONE_ALREADY_EXIST);
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                #endregion

                var contact = await _contactService.CreateContact(contactRequestModel);

                result.Success = true;
                result.Result = contact;

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                _logger.Error(ex.Message);

                result.Success = false;
                result.Errors = new List<string>() { ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        /// <summary>
        /// Get All Conatcts
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetConatcts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = new BaseResponse();

            try
            {
                var contactList = _contactService.GetAllContacts(page, pageSize);

                result.Success = true;
                result.Result = contactList;

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                _logger.Error(ex.Message);

                result.Success = false;
                result.Errors = new List<string>() { ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        /// <summary>
        /// Get Contact By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var result = new BaseResponse();

            try
            {
                #region Validate the input

                if (string.IsNullOrEmpty(id))
                {
                    result.Success = false;
                    result.Errors = new List<string>() { MessageConstant.REQUEST_IS_NULL };
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                #endregion

                var contact = await _contactService.GetContactById(Guid.Parse(id));

                result.Success = true;
                result.Result = contact;

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                _logger.Error(ex.Message);

                result.Success = false;
                result.Errors = new List<string>() { ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateContact(string id, [FromBody] ContactRequestModel contactRequestModel)
        {
            var result = ContactValidationEngine.ValidateContact(contactRequestModel);

            try
            {
                #region Validate the input

                if (!result.Success && result?.Errors?.Count > 0 || string.IsNullOrEmpty(id))
                {
                    result.Errors.Add(MessageConstant.REQUEST_IS_NULL);
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                //Check Email
                if (await _contactService.IsEmailExist(Guid.Empty, contactRequestModel.Email))
                {
                    result.Errors.Add(MessageConstant.EMAIL_ALREADY_EXIST);
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                //Check Phone Number
                if (await _contactService.IsPhoneNumberExist(Guid.Empty, contactRequestModel.PhoneNumber))
                {
                    result.Errors.Add(MessageConstant.PHONE_ALREADY_EXIST);
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                #endregion

                var contact = await _contactService.UpdateContact(Guid.Parse(id), contactRequestModel);

                result.Success = true;
                result.Result = contact;

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                _logger.Error(ex.Message);

                result.Success = false;
                result.Errors = new List<string>() { ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var result = new BaseResponse();

            try
            {
                #region Validate the input

                if (string.IsNullOrEmpty(id))
                {
                    result.Success = false;
                    result.Errors = new List<string>() { MessageConstant.REQUEST_IS_NULL };
                    return StatusCode(StatusCodes.Status400BadRequest, result);
                }

                #endregion

                var contact = await _contactService.DeleteContact(Guid.Parse(id));

                result.Success = true;
                result.Result = contact;

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                _logger.Error(ex.Message);

                result.Success = false;
                result.Errors = new List<string>() { ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }
    }
}
