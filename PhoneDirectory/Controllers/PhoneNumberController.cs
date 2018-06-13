using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneDirectory.Models;
using PhoneDirectory.ViewModels;

namespace PhoneDirectory.Controllers
{
    public class PhoneNumberController : Controller
    {
        private ApplicationDbContext _context;

        public PhoneNumberController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new PhoneNumberFormViewModel();

            return View("PhoneNumberForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(PhoneNumber phoneNumber)
        {
            //Validation for invalid inputs
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new PhoneNumberFormViewModel
            //    {
            //        PhoneNumber = phoneNumber
            //    };

            //    return View("PhoneNumberForm", viewModel);
            //}

            if (phoneNumber.Id == 0)
                _context.PhoneNumbers.Add(phoneNumber);
            else
            {
                var phoneNumberInDb = _context.PhoneNumbers.Single(p => p.Id == phoneNumber.Id);

                phoneNumberInDb.Details = phoneNumber.Details;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "PhoneNumber");
        }

        public ViewResult Index()
        {
            var phoneNumbers = _context.PhoneNumbers.ToList();

            return View(phoneNumbers);
        }

        //public ViewResult Search()
        //{
        //    var phoneNumbers = _context.PhoneNumbers.ToList();

        //    using (_context)
        //    {
        //        var query = _context.PhoneNumbers.Where(p => p.Details == this.TextBoxYourTextBox.Text).ToList();
        //        phoneNumbers = query;
        //        this.YourGridView.DataBind();
        //    }

        //    return View(phoneNumbers);
        //}

        public ActionResult Details(int id)
        {
            var phoneNumber = _context.PhoneNumbers.SingleOrDefault(p => p.Id == id);

            if (phoneNumber == null)
                return HttpNotFound();

            return View(phoneNumber);
        }

        public ActionResult Edit(int id)
        {
            var phoneNumber = _context.PhoneNumbers.SingleOrDefault(p => p.Id == id);

            if (phoneNumber == null)
                return HttpNotFound();

            var viewModel = new PhoneNumberFormViewModel
            {
                PhoneNumber = phoneNumber
            };

            return View("PhoneNumberForm", viewModel);
        }
    }
}