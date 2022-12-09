using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using LogixBoardCodeChallenge.Domain.Interfaces;
using LogixBoardCodeChallenge.Models;
using Newtonsoft.Json;
using LogixBoardCodeChallenge.Domain;
using Api = LogixBoardCodeChallenge.Domain.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var firebaseConfig = configuration.GetSection("Firebase").Get<FirebaseConfig>();
string firebaseConfigSerialized = JsonConvert.SerializeObject(firebaseConfig);

//builder.Services.AddSingleton(_ => new FirestoreRepository(
//    new FirestoreDbBuilder
//    {
//        ProjectId = "logixboard-1c4ce",
//        JsonCredentials = firebaseConfigSerialized
//    }.Build()
//));

builder.Services.AddSingleton<IApi, Api>();
builder.Services.AddSingleton<IFirestoreRepository, FirestoreRepository>(_ => new FirestoreRepository(
    new FirestoreDbBuilder
    {
        ProjectId = "logixboard-1c4ce",
        JsonCredentials = firebaseConfigSerialized
    }.Build()
));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
