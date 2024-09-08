var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();//default olarak loglama mekanizmas� IoS ye kay�t yapmaya gerek yok
builder.Logging.AddConsole();//console log d��
builder.Logging.AddDebug();//debug ortam�na log d��

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();




app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();