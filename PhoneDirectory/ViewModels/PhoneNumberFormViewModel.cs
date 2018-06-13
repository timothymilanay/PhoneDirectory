using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneDirectory.Models;

namespace PhoneDirectory.ViewModels
{
    public class PhoneNumberFormViewModel
    {
        public PhoneNumber PhoneNumber { get; set; }
        public string Title
        {
            get
            {
                if (PhoneNumber != null && PhoneNumber.Id != 0)
                    return "Edit Phone Number";

                return "Add a new Phone Number";
            }
        }
    }
}