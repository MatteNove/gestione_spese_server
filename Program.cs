using gestione_spese_server;
using gestione_spese_server.Interfacce;
using gestione_spese_server.Mapper;
using gestione_spese_server.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrazione del DbContext per SQLite
builder.Services.AddDbContext<DataContext>(options =>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=gestione_spese.db"));

// 2. Registrazione dei Mapper (Singleton)
builder.Services.AddSingleton<IMapperUtente, MapperUtente>();

// 3. Registrazione dei Service
builder.Services.AddSingleton<IServiceUtente, ServiceUtente>();

var app = builder.Build();


