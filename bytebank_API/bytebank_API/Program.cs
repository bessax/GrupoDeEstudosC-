var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Projeto API - ByteBank [Grupo de estudos C#/.NET]");

app.Run();
