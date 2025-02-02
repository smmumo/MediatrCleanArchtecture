
using StockApp.Application;
using StockApp.Infrastructure ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplication()
        .AddInfrastructure(builder.Configuration);

builder.Logging.ClearProviders().AddConsole();

// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// builder.Services.AddCors(options =>
// {
// 	options.AddPolicy(name: MyAllowSpecificOrigins,
// 					  policy =>
// 					  {
// 						  policy.AllowAnyOrigin();
// 						  //policy.WithOrigins("*");
// 						  policy.AllowAnyMethod();
// 						  policy.AllowAnyHeader();
// 						  policy.AllowCredentials();
// 					  });
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(MyAllowSpecificOrigins);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();


