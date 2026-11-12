using Microsoft.OpenApi;
using RecordLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token"
    });

    opt.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", doc),
            new List<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .WithMethods("GET", "POST", "PUT", "DELETE")
                  .AllowAnyHeader();
        });
});

builder.Services.AddSingleton<IRecordRepository, RecordRepositoryList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
