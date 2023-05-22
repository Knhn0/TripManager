using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripManager.Service.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "SERVER";
        public const string AUDIENCE = "CLIENT";
        const string KEY = "THESECRETKEYFORAUTHIREALLYDONTKNOWWHATISHOULDTOPRINTHERE";
        public const int LIFETIME = 1440;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}