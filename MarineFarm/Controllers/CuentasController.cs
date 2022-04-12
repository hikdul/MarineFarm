using AutoMapper;
using MarineFarm.Auth;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
using MarineFarm.Services.MailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        private readonly IMailSender sender;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="sender"></param>
        public CuentasController(
              SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            IMapper mapper,
            IMailSender sender
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.context = context;
            this.mapper = mapper;
            this.sender = sender;
        }

        #endregion


        #region vista inicial
        /// <summary>
        /// vista inicial, vista de mi usuario
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.us = await context
                    .AspNetUsuario
                    .Where(ee => ee.Email.Trim().ToUpper() == User.Identity.Name.Trim().ToUpper())
                    .FirstOrDefaultAsync();

            }catch(Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return RedirectToAction("Logout", "Cuentas");
            }
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


        #region Usuarios, no clientes
        /// <summary>
        /// Para ver a todos los usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Usuarios()
        {
            List<UsuarioDTO_out> list = new();
            try
            {
                var ents = await context.AspNetUsuario
                    .Where(y => y.act == true && y.Rol != "Cliente")
                    .ToListAsync();
                list = mapper.Map<List<UsuarioDTO_out>>(list);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return View(list);
        }


        /// <summary>
        /// vista para crear el gerente de planta
        /// </summary>
        /// <returns></returns>
        public IActionResult CrearUsuarioInternos()
        {
            return View();
        }
        /// <summary>
        /// para Guardar los datos del nuevo genente de planta
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GuardarUsuarioInterno(UsuarioDTO_in ins)
        {

            var aux = await userManager.FindByEmailAsync(ins.Email);
            if (aux != null)
            {

                var result = await userManager.CreateAsync(new IdentityUser()
                {
                    Email = ins.Email,
                    UserName = ins.Email
                }, ins.Psw);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(ins.Email);
                    var usuario = mapper.Map<Usuario>(ins);
                    usuario.Userid = user.Id;
                    context.Add(usuario);
                    await context.SaveChangesAsync();
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, usuario.MyRolIdentity(ins.LvlRol)));

                    //queda enviar el correo. generar una tarea solo para enviar el correo. que cree el body y haga todo en su hilo


                }
                else
                {
                    TempData["Err"] = "Datos No Validos. Verifica de nuevo";
                    return View("CrearUsuarioInternos", ins);
                }

            }
            else
            {
                TempData["Err"] = "Correo Electronico en uso";
                return View("CrearUsuarioInternos", ins);
            }


            return View();
        }

        #endregion
        #region Usuarios, Clientes
        /// <summary>
        /// Para ver a todos los usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Clientes()
        {
            List<UsuarioClienteDTO_out> list = new();
            try
            {
                var ents = await context.UsuarioClientes
                    .Include(y => y.Cliente)
                    .Include(y => y.Usuario)
                    .Where(y => y.Usuario.act == true && y.Cliente.act == true)
                    .ToListAsync();

                list = mapper.Map<List<UsuarioClienteDTO_out>>(ents);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return View(list);
        }


        /// <summary>
        /// vista para crear el gerente de planta
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CrearUsuarioCliente()
        {
            ViewBag.Clientes = await ToSelect.ToSelectITipo<Cliente>(context);
            return View();
        }
        /// <summary>
        /// para Guardar los datos del nuevo genente de planta
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GuardarUsuarioCliente(UsuarioClienteDTO_in ins)
        {
            var aux = await userManager.FindByEmailAsync(ins.Email);
            if (aux != null)
            {
                var result = await userManager.CreateAsync(new IdentityUser()
                {
                    Email = ins.Email,
                    UserName = ins.Email
                }, ins.Psw);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(ins.Email);
                    var usuario = mapper.Map<Usuario>(ins);
                    usuario.Userid = user.Id;
                    context.Add(usuario);
                    await context.SaveChangesAsync();
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, usuario.MyRolIdentity(ins.LvlRol)));
                    UsuarioCliente uc = new()
                    {
                        Clienteid = ins.Clienteid,
                        Usuarioid = usuario.id
                    };
                    context.Add(uc);
                    await context.SaveChangesAsync();
                    //queda enviar el correo. generar una tarea solo para enviar el correo. que cree el body y haga todo en su hilo
                }
                else
                {
                    TempData["Err"] = "Datos No Validos. Verifica de nuevo";
                    return View("CrearUsuarioInternos", ins);
                }

            }
            else
            {
                TempData["Err"] = "Correo Electronico en uso";
                return View("CrearUsuarioInternos", ins);
            }


            return View();
        }

        #endregion

    }
}
