// ------------------------------------------------------------------------------------------------
// Application Entry Point
// ------------------------------------------------------------------------------------------------

using FraudNet.API.Data.Contracts;
using FraudNet.API.Data.Implementations;
using FraudNet.API.Services;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------------------
// Service Container
// ------------------------------------------------------------------------------------------------

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSingleton<IBatchesDataStore, BatchesDataStore>();
builder.Services.AddSingleton<ICompaniesDataStore, CompaniesDataStore>();
builder.Services.AddSingleton<IPayeeDataStore, PayeeDataStore>();
builder.Services.AddSingleton<IPaymentsDataStore, PaymentsDataStore>();

builder.Services.AddTransient<IMailService, LocalMailService>();

var app = builder.Build();

// ------------------------------------------------------------------------------------------------
// HTTP Request Pipeline
// ------------------------------------------------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// -------------------------------------------------------------------------------------------------