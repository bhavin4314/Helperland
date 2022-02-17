using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using System;

namespace Helperland_integration.Repository
{
    public class ContactRepository
    {
        private readonly HelperlandContext _helperlandContext = null;
        public ContactRepository(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        public int SendMessage(ContactViewModel contactViewModel)
        {

                ContactU newMessage = new ContactU();
                newMessage.Name = contactViewModel.FirstName + " " + contactViewModel.LastName;
                newMessage.Email = contactViewModel.Email;
                newMessage.Subject = contactViewModel.Subject;
                newMessage.PhoneNumber = contactViewModel.PhoneNumber;
                newMessage.Message = contactViewModel.Message;
                newMessage.CreatedOn = DateTime.Now.Date;
                _helperlandContext.ContactUs.Add(newMessage);
                _helperlandContext.SaveChanges();
                return newMessage.ContactUsId;
         
        }
    }
}
