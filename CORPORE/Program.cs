using API.Data;
using API.Services.OperadorService;
using API.Services.OrdemServicoService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();

// Saiba mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona serviços de escopo para injeção de dependência
builder.Services.AddScoped<IOperadorInterface, OperadorService>();
builder.Services.AddScoped<IOrdemServicoInterface, OrdemServicoService>();

// Configuração do DbContext para o banco de dados usando SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CORPORE"));
});

// Configuração do CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORPORE", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configura o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuração do CORS
app.UseCors("CORPORE");

// Redireciona para HTTPS
app.UseHttpsRedirection();

// Configuração da autorização
app.UseAuthorization();

// Mapeia os controllers
app.MapControllers();

// Executa a aplicação
app.Run();
