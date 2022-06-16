using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyJWTApi.Models
{
    public interface IJwtAuthenticator
    {
        string TokenGenerator(string email, string username, string password);
    }
}
