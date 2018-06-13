using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneDirectory.Models;

namespace PhoneDirectory.Controllers.Api
{
    public class PhoneNumbersController : ApiController
    {
        private ApplicationDbContext _context;

        public PhoneNumbersController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<PhoneNumber> GetPhoneNumbers()
        {
            return _context.PhoneNumbers.ToList();
        }

        public IHttpActionResult GetPhoneNumber(int id)
        {
            var phoneNumber = _context.PhoneNumbers.SingleOrDefault(p => p.Id == id);

            if (phoneNumber == null)
                return NotFound();

            return Ok(phoneNumber);
        }

        [HttpPost]
        public IHttpActionResult CreatePhoneNumber(PhoneNumber phoneNumber)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.PhoneNumbers.Add(phoneNumber);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + phoneNumber.Id), phoneNumber) ;
        }

        [HttpPut]
        public void UpdateCustomer(int id, PhoneNumber phoneNumber)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var phoneNumberInDb = _context.PhoneNumbers.SingleOrDefault(p => p.Id == id);

            if(phoneNumberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            phoneNumberInDb.Details = phoneNumber.Details;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeletePhoneNumber(int id)
        {
            var phoneNumberInDb = _context.PhoneNumbers.SingleOrDefault(p => p.Id == id);

            if (phoneNumberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.PhoneNumbers.Remove(phoneNumberInDb);
            _context.SaveChanges();
        }
    }
}
