using gestione_spese_server;
using gestione_spese_server.Interfacce;
using gestione_spese_server.Mapper;
using gestione_spese_server.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrazione del DbContext per SQLite
builder.Services.AddDbContext<DataContext>(options =>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=C:\\Users\\hp\\Desktop\\Progetto\\GESTIONE_SPESE\\DB\\gestione_spese.db"));

// 2. Registrazione dei Mapper (Singleton)
builder.Services.AddSingleton<IMapperUtente, MapperUtente>();

// 3. Registrazione dei Service
builder.Services.AddSingleton<IServiceUtente, ServiceUtente>();

builder.Services.AddOpenApi(); //Registrazione nel Container IoC di tutti i servizi interni della libreria OpenApi

var app = builder.Build(); //Prende tutto quello che ho messo in Builder e compila l'applicazione finale

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); //Espone la rotta hhtp ://localhost:5000/openapi per visualizzare la documentazione OpenApi
}

app.UseHttpsRedirection(); //Abilita il redirect automatico da http a https
app.UseAuthorization(); //Abilita il middleware per la gestione dell'autorizzazione

app.MapControllers(); //Crea le rotte per i controller definiti nel progetto

app.Run(); //Avvia l'applicazione e mette in ascolto le richieste http


