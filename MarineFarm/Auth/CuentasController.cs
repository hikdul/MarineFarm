using MarineFarm.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarineFarm.Auth
{
    /// <summary>
    /// controlador para manipular las cuentas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        #region ctor
        // ## ========= inyecciones
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;


        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="_UserManager"></param>
        /// <param name="configuration"></param>
        /// <param name="_SignInManager"></param>
        public CuentasController(
            ApplicationDbContext _context, 
            UserManager<IdentityUser> _UserManager,
            IConfiguration configuration,
            SignInManager<IdentityUser> _SignInManager)
        {
            this.context = _context;
            userManager = _UserManager;
            this.configuration = configuration;
            signInManager = _SignInManager;
        }

        #endregion


        #region login
        /// <summary>
        /// para obtener la llave y acceder al sistema
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo model)
        {
            var resultado = await signInManager.PasswordSignInAsync(model.Email,
                model.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                var usuario = await userManager.FindByNameAsync(model.Email);
                var roles = await userManager.GetRolesAsync(usuario);
                return await ConstruirToken(model, roles);
            }
            else
            {
                return BadRequest("Invalid login attempt");
            }
        }

        #endregion



        #region token

        /// <summary>
        /// para canstruir un token con los datos de login
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        private async Task<UserToken> ConstruirToken(UserInfo userInfo, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim(ClaimTypes.Email, userInfo.Email),
                 new Claim("PasdWord", "XD No Hay Nada -.-!"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var identityUser = await userManager.FindByEmailAsync(userInfo.Email);

            claims.Add(new Claim(ClaimTypes.NameIdentifier, identityUser.Id));

            var claimsDB = await userManager.GetClaimsAsync(identityUser);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddDays(3);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiracion,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };

        }



        #endregion


    }
}
