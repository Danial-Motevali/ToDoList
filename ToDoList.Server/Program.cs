using ToDoList.Application;
using ToDoList.Application.Settings;
using ToDoList.Persistense;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region fill the Settings 

builder.Services.Configure<IdentitySetting>(
    builder.Configuration.GetSection(nameof(IdentitySetting)));

#endregion

#region Add services from other layers

builder.Services.AddApplicatiouLayerServices();
builder.Services.AddPersistenseServices(builder.Configuration);

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
