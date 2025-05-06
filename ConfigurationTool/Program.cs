using ConfigurationTool.Common.ConfigurationFactory;
using ConfigurationTool.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Registering configurations
ConfigurationRegistrar.RegisterConfigurations(builder);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configuring the DI container
builder.Services.AddSingleton<IConfigurationFactory, ConfigurationFactory>();


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
