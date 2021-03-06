﻿using Cz.Bkk.Generic.Common.Models.Exceptions;
using Cz.Bkk.Generic.Common.Models.Input;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.LogicLayer
{
    internal class Registration : IRegistration
    {
        private readonly IRegistrationService service;

        public Registration(IRegistrationService service)
        {
            this.service = service;
        }

        public async Task<string> CreateAsync(UserInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"{nameof(input)} is null.");
            }
            var response = await service.CreateAsync(input);

            if (response?.Errors?.Count() > 0)
            {
                var errors = string.Join(" ", response?.Errors?.Select(e => e.Description));
                throw new NotCreatedException(errors);
            }

            return null;
        }
    }
}
