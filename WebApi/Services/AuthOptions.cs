using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Services
{
    public class AuthOptions
    {
        public const string ISSUER = "TankistPro";
        public const string AUDIENCE = "Test";
        const string KEY = "123123_*1wQwe/#m12&9!123";
        public const int LIFETIME = 5;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
