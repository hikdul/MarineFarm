using MarineFarm.Data;
using MarineFarm.Services.MailServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var Config = builder.Services.BuildServiceProvider().GetService<IConfiguration>();


// Add services to the container.


// ## === ##
// swagger
// ## === ##
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ## === ##
// Auth scheme
// ## === ##

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(O =>
{
    O.SaveToken = true;
    O.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["jwt:key"])),
        ClockSkew = TimeSpan.Zero
    };
});

// ## === ##
// cookies conf
// ## === ##
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Cuentas/Login";
    options.Cookie.Name = "YourAppCookieName";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/Cuentas/Login";
    options.LogoutPath = "/Cuentas/Login";
    options.SlidingExpiration = true;
});



// ## === ##
// Politicas de cors
// ## === ##
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// ## === ##
// Configuro Swagger
// ## === ##
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Terminal Pesquero",
        Version = "V-0.0.1",
        Description = "App para gestionar los tiempos de produccion de una empresa productora de mariscos congelados",
        Contact = new OpenApiContact()
        {
            Name = "Hector Contreras",
            Email = "hikdul.dev@gmail.com"
        }

    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                    },
                        new string[]{ }
                    }
                });
});
// ## === ##
// Configuro Automapper
// ## === ##
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// ## === ##
// Configuro Base de datos
// ## === ##


//instancio los valores para mi base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(Config.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//para el identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



/// <summary>
/// para los controladores de api y vistas
/// </summary>
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// para controlar el error en el pipeline
builder.Services.AddHealthChecks();

// ## === ##
// ## === ##
// ## ===> para colocar mis servicios

// para introduci r los valores de mi smtp settings, y envie mis correos
builder.Services.Configure<SMTPConf>(Config.GetSection("MailSetup"));
// aqui genero mi servicio, creo que deberia se ser transa..
// pero lo recomiendan singleton. claro en el ejempo el email se enviar 
// directamente desde un formulario. por tanto lo cambio a trans por eso!!>
builder.Services.AddSingleton<IMailSender, EmailSenderServices>();

// ==> arranca la app y construccion en pipeline

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();
