using ApiVendas.Services;
using ApiVendas.Models;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DatabaseSettingsModels>(
    builder.Configuration.GetSection("API")
);

builder.Services.AddSingleton<VendedorService>();
builder.Services.AddSingleton<OportunidadeService>();
builder.Services.AddSingleton<ApiService>();
builder.Services.AddHttpClient("apicnpj", c =>

  c.BaseAddress = new Uri("https://publica.cnpj.ws/")
); ;
//builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEvirioment.BaseAddress) });
// Add services to the container.

/// Serialization Enuns using JsonOptions or AddNewtonsoft
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Suport for Enum
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddSwaggerGen( s =>
{
    /// Describe name API
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Vendas" , Version = "v1"});
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
