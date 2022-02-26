using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(SqlRepositoryGeneric<>));
builder.Services.AddScoped<DbContext, SqlDbContext>();
//builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionAlexis")));
builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionJohan")));


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

builder.Services.AddControllers().AddNewtonsoftJson(
    opt => opt.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DbContext>();

    context.Database.Migrate();
}

app.UseCors(MyAllowSpecificOrigins);



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
