using Shop.Domain.Entities.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users
{
    public class UserDomainService : IDomainUserService
    {
        public bool IsEmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public bool PhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
