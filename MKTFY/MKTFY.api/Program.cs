// Setup low-level functionality like configuration providers.ect.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MKTFY.api.Swashbuckle;
using MKTFY.Repositories;
using MKTFY.Services.Services;
using MKTFY.Services.Services.Interfaces;


void ConfigureHost(ConfigureHostBuilder host)
{
}


// Setup services like database providers. ect
void ConfigureServices(WebApplicationBuilder builder)
{
    // Setup the Database using the Application DbContext
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(  //connect to the postgres database
            builder.Configuration.GetConnectionString("DefaultConnection"),
            npgsqlOptions =>
            {
                // Configure what project we want to store our code-first Migrations in.
                npgsqlOptions.MigrationsAssembly("MKTFY.Repositories");
            })
        );

    // setup Authenitcation
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.Authority = builder.Configuration.GetSection("Auth0").GetValue<string>("Domain");
            options.Audience = builder.Configuration.GetSection("Auth0").GetValue<string>("Audience");
            options.TokenValidationParameters = new TokenValidationParameters
            {
                RoleClaimType = "http://schemas.mktfylex.com/roles"
            };

        });

    //Add Swagger generator to creat JSON documentaition content
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "MKTFY API", Version = "v1" });
        var apiXmlFilename = Path.Combine(AppContext.BaseDirectory, "MKTFY.api.xml");
        var modelsXmlFilename = Path.Combine(AppContext.BaseDirectory, "MKTFY.Models.xml");
        options.IncludeXmlComments(apiXmlFilename);
        options.IncludeXmlComments(modelsXmlFilename);

        options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Scheme = "bearer"
        });
        options.OperationFilter<AuthHeaderOperationFilter>();
    });

    builder.Services.AddControllers();

    //Setup dependency Injection
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IListingService, ListingService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUploadService, UploadService>();
}

// Setup out HTTP request/response pipeline
void ConfigurePipeline(WebApplication app)
{
    //app.UseHttpsRedirection(); // we are not using Https localy and it could make it tricky runing with out docker you can keep it on. 

    //Allow Hosting of static web files
    if (!app.Environment.IsProduction())
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        //Make Swagger Json File avalible 
        app.UseSwagger();

        // Make Swagger UI available at /swagger
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MKTFY API v1");
        });

    }

    // If we get to admin panel to block user we would build a spot in here app.BlockedUser() not this exact code but something like this 
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

}

//Execute database migrations
void ExecuteMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}

// Create the WebApplication Builder instance
var builder = WebApplication.CreateBuilder(args);

//Setup the application 
ConfigureHost(builder.Host);
ConfigureServices(builder);

var app = builder.Build();

//Excute migraions on startup
ExecuteMigrations(app);

// Setup the Http Pipeline
ConfigurePipeline(app);

app.Run();


