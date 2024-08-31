using HR_Management.Application;
using HR_Management.Identity;
using HR_Management.Infrastructure;
using HR_Management.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
AddSwagger(builder.Services);

ApplicationServicesRegisteration.Configure(builder.Services);
InfrastructureServicesRegisteration.Configure(builder.Services, builder.Configuration);
PersistenceServicesRegisteration.Configure(builder.Services, builder.Configuration);
IdentityServicesRegisteration.Configure(builder.Services, builder.Configuration);


builder.Services.AddCors(x =>
{
    x.AddPolicy("CorsPolicy", b =>
    {
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();


#region Configure Swagger

static void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
        {
            Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 1234sddsw'",
            Name = "Authorization",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });

        options.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "HR Management Api"
        });
    });
}

#endregion