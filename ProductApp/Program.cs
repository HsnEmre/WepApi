var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();//default olarak loglama mekanizmasý IoS ye kayýt yapmaya gerek yok
builder.Logging.AddConsole();//console log düþ
builder.Logging.AddDebug();//debug ortamýna log düþ

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();




app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();