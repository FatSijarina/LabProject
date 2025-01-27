using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.Services.Implementation.PersonsServices;
using CaseTrackingAPI.Services.Implementation;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using CaseTrackingAPI.Services.Implementation.EvidenceServices;
using CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces;
using CaseTrackingAPI.Services.Implementation.PersonsServices.CaseTrackingAPI.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CaseDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<CaseService>();
builder.Services.AddScoped<IVictimService, VictimService>();
builder.Services.AddScoped<IWitnessService, WitnessService>();
builder.Services.AddScoped<ISuspectService, SuspectService>();
builder.Services.AddScoped<IBiologicalEvidenceService, BiologicalEvidenceService>();
builder.Services.AddScoped<IEvidenceService, EvidenceService>();
builder.Services.AddScoped<IPhysicalEvidenceService, PhysicalEvidenceService>();
builder.Services.AddScoped<IBiologicalTraceService, BiologicalTraceService>();
builder.Services.AddScoped<IStatementService, StatementService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IInvolvedParty, InvolvedPartyService>();
builder.Services.AddScoped<ICaseService, CaseService>();
builder.Services.AddScoped<IFileService, FileService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();