global using dtms_service_master.Models.Context;
using dtms_service_master.Controllers;
using dtms_service_master.Models;
using dtms_service_master.Repositories;
using dtms_service_master.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcHttpApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddGrpcSwagger();

builder.Services.AddGrpcReflection();

builder.Services.AddCors(o =>
    o.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders(
                    "Grpc-Status",
                    "Grpc-Message",
                    "Grpc-Encoding",
                    "Grpc-Accept-Encoding");
    }));

builder.Services.AddDbContextFactory<ServiceMasterContext>(
    options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRepository();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "gRPC HTTP API Example V1");
});

app.UseRouting();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.UseCors();

if (app.Environment.IsDevelopment())
    app.MapGrpcReflectionService();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GreeterService>();
    endpoints.MapGrpcService<DummyController>();
    endpoints.MapGrpcService<VendorController>();
});

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
