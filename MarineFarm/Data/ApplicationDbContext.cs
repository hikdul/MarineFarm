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

        // ## == Adicional para aspNetIdentity
        // ## =====================================

        /// <summary>
        /// donde se almacena la data sensible del usuario
        /// </summary>
        public DbSet<Usuario> AspNetUsuario { get; set; }



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


        #endregion

        /// <summary>
        /// para la gegeracion de datos por defecto
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
          //  RolesYSU(builder);

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
           // builder.Entity<CostosMes>().HasKey(x => new { x.Equipoid, x.Mariscoid, x.TipoProduccionid, x.Calibreid });
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

            builder.Entity<IdentityUser>().HasData(SuperAdmin);
            builder.Entity<IdentityRole>().HasData(RoleSistAdmin);
            builder.Entity<IdentityRole>().HasData(RoleGtePlanta);
            builder.Entity<IdentityRole>().HasData(RoleCliente);
            builder.Entity<IdentityRole>().HasData(RoleSuperv);

            builder.Entity<IdentityUserRole<string>>().HasData(hikdul);

        }

        #endregion




    }
}