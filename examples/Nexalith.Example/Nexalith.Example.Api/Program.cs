using System.Reflection;
using Nexalith.Api;
using Nexalith.Example.Application;
using Nexalith.Example.Persistence;
using Nexalith.Example.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

var assembly = Assembly.GetExecutingAssembly();

builder.Services
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddNexalithApi(assembly);

var app = builder.Build();

app.UseNexalithApi();

await app.MigrateDatabaseAsync();

app.Run();