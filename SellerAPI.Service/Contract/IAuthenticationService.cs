using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Service.Contract
{
   public interface IAuthenticationService
    {
      public Task<string> GenerateSecurityToken(string email);
    }
}
