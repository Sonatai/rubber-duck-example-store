using API.DataAccess;
using API.Profiles;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddAutoMapper(typeof(DomainProfile));

builder.Services.AddSingleton(service => builder.Configuration
    .GetSection("DatabaseSettings")
    .Get<DatabaseSettings>()
);

builder.Services.AddSingleton<CartsService>();


//Don't do this for production..
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(opt =>
    {
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
        opt.AllowAnyOrigin();
    });
});

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
