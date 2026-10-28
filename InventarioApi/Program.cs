var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<InventarioApi.Repositories.ProductoMemoryStore>();
builder.Services.AddScoped<InventarioApi.Repositories.IProductoRepository, InventarioApi.Repositories.ProductoRepositoryMemory>();
builder.Services.AddScoped<InventarioApi.Services.IProductoService, InventarioApi.Services.ProductoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
