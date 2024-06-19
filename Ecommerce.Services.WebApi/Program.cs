using Ecommerce.Services.WebApi.Modules.Authentication;
using Ecommerce.Services.WebApi.Modules.Features;
using Ecommerce.Services.WebApi.Modules.HealthChecks;
using Ecommerce.Services.WebApi.Modules.Inyection;
using Ecommerce.Services.WebApi.Modules.Mapper;
using Ecommerce.Services.WebApi.Modules.Swagger;
using Ecommerce.Services.WebApi.Modules.Validator;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInyections(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddSwagger();
builder.Services.AddValidators();
builder.Services.AddHealthCheck(builder.Configuration);

var app = builder.Build();

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting().UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecksUI(options => options.AddCustomStylesheet("Modules/HealthChecks/Styles/dotnet.css"));
    endpoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    });
});

app.UseAuthentication();
app.UseAuthorization();


app.Run();

public partial class Program { }
