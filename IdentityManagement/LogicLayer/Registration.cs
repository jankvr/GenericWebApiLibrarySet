using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Cz.Bkk.Generic.IdentityManagement.Models;
using Cz.Bkk.Generic.IdentityManagement.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.LogicLayer
{
    public class Registration : IRegistration
    {
        private readonly RegistrationService service;

        public Registration(RegistrationService service)
        {
            this.service = service;
        }

        public async Task<bool> CreateAsync(string username, string firstname, string lastname, string email)
        {
            var input = new RegistrationInput 
            { 
                FirstName = firstname, 
                LastName = lastname, 
                Password = "asdf",
                Email = email,
                Username = username
            };
            var result = await service.CreateAsync(input);
            return result.Succeeded;
        }
    }
}
