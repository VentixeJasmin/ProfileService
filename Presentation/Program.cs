using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Presentation;
using Presentation.Data;
using Presentation.ServiceBus;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSingleton<ServiceBusClient>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("ServiceBus");
    return new ServiceBusClient(connectionString);
});
builder.Services.AddHostedService<AccountCreatedMessageHandler>();
builder.Services.AddDbContext<ProfileContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProfileDatabaseConnection")));
builder.Services.AddScoped<ProfileService>(); 

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
