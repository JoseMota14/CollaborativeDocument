using EventSourcingCollaborativeDocs.Hubs;
using EventSourcingCollaborativeDocs.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastucture(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<DocumentHub>("/documentHub");
    endpoints.MapControllers();
});

app.Run();
