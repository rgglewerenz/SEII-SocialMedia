using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var AllowedConnections = builder.Configuration.GetRequiredSection("AllowedConnections");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin();
        });
    options.AddPolicy("AllowSpesificOrigins",
        builder =>
        {
            var allowedUrls = AllowedConnections.Get<List<string>>();
            allowedUrls.ForEach(url =>
            {
                builder.WithOrigins(url)
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

if (builder.Configuration.GetRequiredSection("AllowAllConnections").Get<bool>())
    app.UseCors("AllowAllOrigins");
else
    app.UseCors("AllowSpesificOrigins");



app.UseAuthorization();

app.MapControllers();

app.Run();
