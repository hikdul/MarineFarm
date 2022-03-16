using AutoMapper;
using MarineFarm.Auth;
using MarineFarm.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para manipular los datos de usuarios
    /// </summary>
    [Authorize]
    public class CuentasController : Controller
    {

        #region ctor

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CuentasController(
              SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            IMapper mapper
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.context = context;
            this.mapper = mapper;
        }

        #endregion


        #region vista inicial
        /// <summary>
        /// vista inicial, vista de mi usuario
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }


        #endregion



        #region logIn
        /// <summary>
        /// vista para ingresar al sistema
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> login()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            HttpContext.Response.Cookies.Delete("Token");
            if (User.Identity.IsAuthenticated)
                await signInManager.SignOutAsync();
            return View();
        }
        /// <summary>
        /// verifica si el usuario existe y le permite el paso a la app
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> Singin(UserInfo userInfo)
        {
            HttpClient client = new();
            try
            {
                UserToken tk;
                var result = await signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var usuario = await userManager.FindByEmailAsync(userInfo.Email);
                    var roles = await userManager.GetRolesAsync(usuario);

                    if (roles.Count < 1 || roles == null)
                        roles = new List<string>();

                    tk = new UserToken(userInfo, roles, configuration);
                    HttpContext.Response.Cookies.Append("Token", tk.Token, new Microsoft.AspNetCore.Http.CookieOptions()
                    {
                        Expires = tk.Expiracion
                    });

                    await signInManager.PasswordSignInAsync(usuario, userInfo.Password, false, false);
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Err = "El correo o la contraseña no son correctos.";
                return View("login");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                ViewBag.Err = "El correo o la contraseña no son correctos.";
                return View("login");
            }
            finally
            {
                client.Dispose();

            }

        }
        /// <summary>
        /// para salir del sistema
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            HttpContext.Response.Cookies.Delete("Token");
            await signInManager.SignOutAsync();
            Response.Redirect("Login");
            return View("Login");
        }

        #endregion



    }
}
