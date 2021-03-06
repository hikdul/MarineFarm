using MarineFarm.Auth;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Data
{
    /// <summary>
    /// configuracion del contexto de datos
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// constructor de mi proyecto
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Tablas de negocio

        // ## == Complemento de datos para usuarios
        // ## =====================================

        /// <summary>
        /// donde se almacena la data sensible del usuario
        /// </summary>
        public DbSet<Usuario> AspNetUsuario { get; set; }
        /// <summary>
        /// Usuario del sistema para nuestros cliente
        /// </summary>
        public DbSet<UsuarioCliente> UsuarioClientes{ get; set; }

        // ## == Sobre la construccion de productos
        // ## =====================================


        /// <summary>
        /// tabla que contiene mis mariscos
        /// </summary>
        public DbSet<Marisco> Mariscos { get; set; }
        /// <summary>
        /// almacena los calibres de uso de la aplicacion
        /// </summary>
        public DbSet<Calibre> Calibres { get; set; }

        /// <summary>
        /// almacena el modo de empaquetado de nuestros productos
        /// </summary>
        public DbSet<Empaquetado> Empaquetados { get; set; }
        /// <summary>
        /// almacena los tipos de produccion
        /// </summary>
        public DbSet<TipoProduccion> TiposProduccion { get; set; }

        /// <summary>
        /// almacena lo productos como una unidad reutilizable
        /// </summary>
        public DbSet<Producto> Productos { get; set; }


        // ## == Stock
        // ## =====================================

        /// <summary>
        /// Para tener el inventario de materia prima
        /// </summary>
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        /// <summary>
        /// para llevar el historial de materio prima
        /// ingreso y egresos
        /// </summary>
        public DbSet<HistorialMateriaPrima> HistorialMateriaPrima { get; set; }

        /// <summary>
        /// de lo que hay en este momento en almacen
        /// </summary>
        public DbSet<Almacen> Almacen { get; set; }

        // ## == Produccion
        // ## =====================================

        /// <summary>
        /// produccion realizada
        /// </summary>
        public DbSet<Produccion> Produccion { get; set; }
        /// <summary>
        /// Mariscos usados en la produccion
        /// </summary>
        public DbSet<PMariscoProduccion> MariscoProduccion { get; set; }

        /// <summary>
        /// producto realizado en produccion
        /// </summary>
        public DbSet<PProductoProduccion> ProductoProduccion { get; set; }


        // ## == Planta
        // ## =====================================

        /// <summary>
        /// cargos
        /// </summary>
        public DbSet<Cargos> Cargos { get; set; }
        /// <summary>
        /// turnos
        /// </summary>
        public DbSet<Turnos> Turnos { get; set; }

        /// <summary>
        /// tabla de equipos
        /// </summary>
        public DbSet<Equipo> Equipos { get; set; }
        /// <summary>
        /// Bonos
        /// </summary>
        public DbSet<Bono> Bonos { get; set; }

        // ## == Manejo de Pedidos
        // ## =====================================
        /// <summary>
        /// para almacenar los datos generales de los clientes
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }
        /// <summary>
        /// Para almacenar los datos base de los pedidos
        /// </summary>
        public DbSet<Pedido> Pedidos { get; set; }
        /// <summary>
        /// pivote de pedidos en productos
        /// </summary>
        public DbSet<PedidosProductos> PP { get; set; }
        /// <summary>
        /// Muestras Diarias
        /// </summary>
        public DbSet<MuestraDiaria> MuestrasDiarias { get; set; }
        /// <summary>
        /// contiene los pedidos que se han eliminado
        /// </summary>
        public DbSet<PedidoEliminado> PedidosEliminados { get; set; }

        // ## == Para conf valores utiles en toda la pp
        // ## =====================================

        /// <summary>
        /// Almacena la conf del sistema
        /// </summary>
        public DbSet<Configuraciones> Config { get; set; }

        #endregion

        /// <summary>
        /// para la gegeracion de datos por defecto
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //RolesYSU(builder);

            BuildKey(builder);

            base.OnModelCreating(builder);
        }

        #region asignacion de llaves
        /// <summary>
        /// para generar las claves compuestas en base de datos
        /// </summary>
        /// <param name="builder"></param>
        private void BuildKey(ModelBuilder builder)
        {
            builder.Entity<PMariscoProduccion>().HasKey(x => new { x.Produccionid, x.Mariscoid });
            builder.Entity<PProductoProduccion>().HasKey(x => new { x.Produccionid, x.Productoid });
            builder.Entity<Equipo>().HasKey(x => new { x.Turnoid, x.Cargoid });
            builder.Entity<PedidosProductos>().HasKey(x => new { x.pedidoid, x.Productoid });
            builder.Entity<MuestraDiaria>().HasKey(x => new { x.ano, x.mes, x.Mariscoid, x.TipoProduccionid, x.Calibreid, x.Empaquetadoid });
            builder.Entity<UsuarioCliente>().HasKey(x => new { x.Clienteid, x.Usuarioid});
        }

        #endregion

        #region Seed Data
        /// <summary>
        /// para crear el listado de roles y un super usuario para iniciar la partida
        /// </summary>
        /// <param name="builder"></param>

        private void RolesYSU(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var SuperAdmin = new IdentityUser()
            {
                Id = "445f6fc1-5dd4-4c32-af61-19a91b8f1367",
                Email = "hikdul.dev@gmail.com",
                NormalizedEmail = "hikdul.dev@gmail.com".ToUpper(),
                UserName = "hikdul.dev@gmail.com",
                NormalizedUserName = "hikdul.dev@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+51 931 084 717",
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Alau123#")

            };

            var SuperAdminReal = new IdentityUser()
            {
                Id = "1e20113c-7fef-4c00-90b7-c286fba79757",
                Email = "comercial.granjamar@gmail.com",
                NormalizedEmail = "comercial.granjamar@gmail.com".ToUpper(),
                UserName = "comercial.granjamar@gmail.com",
                NormalizedUserName = "comercial.granjamar@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+56 9 9842 9393",
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Alau123#")

            };
            var RoleSistAdmin = new IdentityRole()
            {

                Id = "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9",
                Name = "AdmoSistema",
                NormalizedName = "AdmoSistema".ToUpperInvariant()

            };

            var RoleGtePlanta = new IdentityRole()
            {

                Id = "8f36838c-81ae-4d20-83a0-b867fd489771",
                Name = "Gerenteplanta",
                NormalizedName = "Gerenteplanta".ToUpperInvariant()

            };

            var RoleSuperv = new IdentityRole()
            {

                Id = "a6b2b621-d728-428e-a2be-bc8d30aed151",
                Name = "Superv",
                NormalizedName = "Superv".ToUpperInvariant()

            };

            var RoleCliente = new IdentityRole()
            {

                Id = "6e1b4175-cf9c-4fd2-ab0d-987f5af67434",
                Name = "Cliente",
                NormalizedName = "Cliente".ToUpperInvariant()

            };


            var hikdul = new IdentityUserRole<string>()
            {
                RoleId = RoleSistAdmin.Id,
                UserId = SuperAdmin.Id
            };
            var angel = new IdentityUserRole<string>()
            {
                RoleId = RoleSistAdmin.Id,
                UserId = SuperAdminReal.Id
            };

            builder.Entity<IdentityUser>().HasData(SuperAdmin);
            builder.Entity<IdentityUser>().HasData(SuperAdminReal);
            builder.Entity<IdentityRole>().HasData(RoleSistAdmin);
            builder.Entity<IdentityRole>().HasData(RoleGtePlanta);
            builder.Entity<IdentityRole>().HasData(RoleCliente);
            builder.Entity<IdentityRole>().HasData(RoleSuperv);

            builder.Entity<IdentityUserRole<string>>().HasData(hikdul);
            builder.Entity<IdentityUserRole<string>>().HasData(angel);

        }

        #endregion




    }
}