using ProtoBuf;
using TicTacToeApi.Models;
using WebApiContrib.Core.Formatter.Protobuf;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddProtobufFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.IncludeXmlComments($"{System.AppContext.BaseDirectory}ProjectDoc.xml"));

var app = builder.Build();

app.UseSwagger( options => { });
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
