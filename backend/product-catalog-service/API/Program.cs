using Rubber.Duck.Store.Product.Catalog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton(service => builder.Configuration
    .GetSection("AppConfig")
    .Get<AppConfig>()
);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI()
    ;
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDeveloperExceptionPage();

app.MapControllers();

app.Run();
