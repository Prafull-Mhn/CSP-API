using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Services.Handlers
{
    public class Token
    {
        public static string GenerateToken()
        {
            // Define const Key this should be private secret key  stored in some safe place
            string key = "UFMwMDE5NDA1YTMzMmZiMWJkMmZmZmViMzA4MzUwZjAzMjczM2JhMw==";

            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft
               .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, "HS256");

            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            var payload = new JwtPayload
           {
                {"timestamp", DateTimeOffset.Now.ToUnixTimeMilliseconds()},
                {"partnerId","PS001940" },
                { "reqid","122244"},
    };

            //
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);
            return tokenString;

        }
    }
}
