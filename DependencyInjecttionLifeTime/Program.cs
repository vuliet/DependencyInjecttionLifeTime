using DependencyInjecttionLifeTime;
using DependencyInjecttionLifeTime.Services;
using DependencyInjecttionLifeTime.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISingletonService, SingletonService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddTransient<ITransientService, TransientService>();

builder.Services.AddScoped(p =>
{
    var random = new Random();

    var appUser = new AppUser
    {
        Name = "Thai Vu",
        Index = random.Next(1, 100),
    };

    return appUser;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
