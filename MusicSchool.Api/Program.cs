using Autofac;
using Autofac.Extensions.DependencyInjection;
using MusicSchool.Infrastructure.AutofacModules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();      // Para describir tus endpoints
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule<RepositoryModules>();
    container.RegisterModule<ApplicationModules>();
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicSchool API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
