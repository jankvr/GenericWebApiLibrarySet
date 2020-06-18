using Cz.Bkk.Generic.IdentityManagement.IntegrationLayer;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Cz.Bkk.Generic.IdentityManagement.Models;
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

        public async Task<bool> CreateAsync(RegistrationInput input)
        {
            var result = await service.CreateAsync(input);
            return result.Succeeded;
        }
    }
}
