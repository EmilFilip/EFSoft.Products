var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    _ = builder.Configuration.AddAzureAppConfiguration(options =>
    {
        _ = options.Connect(appConfigurationConnectionString)
                .ConfigureRefresh(refresh =>
                {
                    _ = refresh.Register("Settings:Sentinel", refreshAll: true).SetRefreshInterval(new TimeSpan(0, 1, 0));
                });
    });
}

builder.Services.AddCarter();
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
builder.Services.AddHealthChecks();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Products Microservice", Version = "v1" });
});

_ = builder.Services.RegisterLocalServices(builder.Configuration);

var app = builder.Build();
app.MapCarter();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products Microservice V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
