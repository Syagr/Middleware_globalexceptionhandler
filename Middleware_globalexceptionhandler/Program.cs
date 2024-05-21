using Middleware_globalexceptionhandler.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalExeptionHandlingMiddleware>();
builder.Services.AddTransient<CustomMiddleware01>();
builder.Services.AddTransient<CustomMiddleware02>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CustomMiddleware01>();
app.UseMiddleware<GlobalExeptionHandlingMiddleware>();
app.UseMiddleware<CustomMiddleware02>();

app.UseDeveloperExceptionPage();

app.MapControllers();

app.Run();
