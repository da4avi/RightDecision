using RightDecisionPlayer.Configurations;

var builder = WebApplication.CreateBuilder(args);

//banco config
builder.Services.AddDbConfig(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//masstransit
builder.Services.AddMassTransitConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//https
app.UseHttpsRedirection();

//auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
