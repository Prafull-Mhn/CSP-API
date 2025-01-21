using CSP.Application.Common.Interfaces;
using CSP.Infrastructure.Persistence;
using MediatR;
using Microsoft.OpenApi.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CSP.Application.Users.Queries;
using CSP.Application.Services.Command;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Add Dapper repositories to the DI container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["Swagger:User API"],
        Version = builder.Configuration["Swagger:1.0"],
        Description = builder.Configuration["Swagger:APIs for User"]
    });
});

// Configure Dapper as the ORM
builder.Services.AddTransient<IDbConnection>(_ =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories and MediatR handlers
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserStatusQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(HLRCheckCommand).Assembly));


// Configure CORS if needed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger(c=>
//    {
//        c.RouteTemplate= "User/api/{documentName}/swagger.json";
//    });
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint($"/CSP/api/v1/swagger.json", builder.Configuration["CSPApplication API V1"]);
//      //  c.RoutePrefix = "User/api/swagger"; // Set Swagger as the default page
//        c.RoutePrefix = "CSP/api/swagger";
//    });
//}


app.UseSwagger(c =>
{
    c.RouteTemplate = "CSP/api/{documentName}/swagger.json";
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/CSP/api/v1/swagger.json", builder.Configuration["CSPApplication API V1"]);
    //  c.RoutePrefix = "User/api/swagger"; // Set Swagger as the default page
    c.RoutePrefix = "CSP/api/swagger";
});


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
