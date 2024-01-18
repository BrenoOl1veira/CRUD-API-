using API.Data;
using API.Services.OperadorService;
using API.Services.OrdemServicoService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();

// Saiba mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona servi�os de escopo para inje��o de depend�ncia
builder.Services.AddScoped<IOperadorInterface, OperadorService>();
builder.Services.AddScoped<IOrdemServicoInterface, OrdemServicoService>();

// Configura��o do DbContext para o banco de dados usando SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CORPORE"));
});

// Configura��o do CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORPORE", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configura o pipeline de solicita��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura��o do CORS
app.UseCors("CORPORE");

// Redireciona para HTTPS
app.UseHttpsRedirection();

// Configura��o da autoriza��o
app.UseAuthorization();

// Mapeia os controllers
app.MapControllers();

// Executa a aplica��o
app.Run();
