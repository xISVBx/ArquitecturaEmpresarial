using Ecommerce.Services.WebApi.Modules.Authentication;
using Ecommerce.Services.WebApi.Modules.Features;
using Ecommerce.Services.WebApi.Modules.Inyection;
using Ecommerce.Services.WebApi.Modules.Mapper;
using Ecommerce.Services.WebApi.Modules.Swagger;
using Ecommerce.Services.WebApi.Modules.Validator;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
