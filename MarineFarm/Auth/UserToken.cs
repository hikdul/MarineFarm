using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarineFarm.Auth
{
    /// <summary>
    /// token de usuario dentro de la aplicacion
    /// </summary>
    public class UserToken
    {
        #region props
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// fecha de expiracion
        /// </summary>
        public DateTime Expiracion { get; set; }

        #endregion

        #region construir el Token
        /// <summary>
        /// contructor Por Defecto
        /// </summary>
        public UserToken()
        {
            this.Token = null;
            this.Expiracion = DateTime.Now;
        }

        /// <summary>
        /// para contruor el token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="roles"></param>
        /// <param name="_configuration"></param>
        /// <returns></returns>
        public UserToken(UserInfo userInfo, IList<string> roles, IConfiguration _configuration)
        {
            try
            {

                var claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("PasdWord", "XD No Hay Nada -.-!"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
                var expiration = DateTime.UtcNow.AddDays(7);

                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: null,
                   audience: null,
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds);


                this.Token = new JwtSecurityTokenHandler().WriteToken(token);
                this.Expiracion = expiration;

            }
            catch (Exception x)
            {
                Console.WriteLine("Exception Catch!!");
                Console.WriteLine("Messeger {0}", x.Message);

                this.Token = null;
                this.Expiracion = DateTime.Now;

            }
        }

        #endregion



    }
}
