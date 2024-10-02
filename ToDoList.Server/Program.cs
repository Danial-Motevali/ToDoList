using ToDoList.Application;
using ToDoList.Application.Settings;
using ToDoList.EndPoint.CustomMiddlware;
using ToDoList.EndPoint.Extenstion;
using ToDoList.Persistense;
using ToDoList.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region fill the Settings 

builder.Services.Configure<IdentitySetting>(
    builder.Configuration.GetSection(nameof(IdentitySetting)));

builder.Services.Configure<HashingSetting>(
    builder.Configuration.GetSection(nameof(HashingSetting)));

#endregion

#region Add services from other layers

builder.Services.AddApplicatiouLayerServices();
builder.Services.AddIdntityLayerService(builder.Configuration);
builder.Services.AddPersistenseServices(builder.Configuration);
builder.Services.AddEndPointServices();

#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorMiddlware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
