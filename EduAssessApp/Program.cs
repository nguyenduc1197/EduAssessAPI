using Application.Accounts.Commands;
using Application.Class.Queries;
using Application.Common.Mappings;
using Application.DTOs;
using Application.Exams.Commands;
using Application.Exams.Queries;
using Application.Exams.Queries.GetById;
using Application.Interfaces;
using Application.Questions.Commands;
using Application.Questions.Queries;
using Application.Questions.Queries.GetByExam;
using Application.Questions.Queries.GetById;
using Application.StudentExamAnswers.Commands.Create;
using Application.Teachers.Commands;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDev",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // React dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// 🗄️ SQL Server DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
TypeAdapterConfig.GlobalSettings.Scan(typeof(MapsterConfiguration).Assembly);

builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);

// Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IChoiceRepository, ChoiceRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<IStudentExamRepository, StudentExamRepository>();
builder.Services.AddScoped<IStudentExamAnswerRepository, StudentExamAnswerRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IMapper, Mapper>();
// Mediator
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateQuestionHandler).Assembly);
});

// 🔐 Auth, Logging, Swagger
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.UseCors("AllowReactDev");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "EduAssessSystem API is running ✅");

app.MapPost("/api/exams/submit", async (AppDbContext db, Student student) =>
{
    db.Students.Add(student);
    await db.SaveChangesAsync();

    return Results.Ok(new
    {
        Name = "Nguyen Van A",
        DateOfBirth = DateTime.Now
    });
}).RequireAuthorization(x => x.RequireRole("Student"));

//Login
app.MapPost("/login", async (LoginCommand command, IMediator mediator) =>
{
    var loginResponse = await mediator.Send(command);

    return loginResponse is null
        ? Results.Unauthorized()
        : Results.Ok(new { loginResponse });
});

//Question
app.MapPost("/questions", async (CreateQuestionCommand command, IMediator mediator) =>
{
    var questionId = await mediator.Send(command);
    return Results.Created($"/questions/{questionId}", questionId);
}).RequireAuthorization();

app.MapGet("/questions/{id}", async (Guid id, IMediator mediator) =>
{
    var question = await mediator.Send(new GetQuestionByIdQuery(id));
    return question is not null ? Results.Ok(question) : Results.NotFound();
}).RequireAuthorization();

app.MapGet("/questions", async (int pageNumber, int pageSize, Guid? examId, IMediator mediator) => 
{
    if (examId.HasValue)
    {
        var questionsByExam = await mediator.Send(
            new GetQuestionsByExamIdQuery(examId.Value)
        );

        return Results.Ok(questionsByExam);
    }

    var questions = await mediator.Send(
        new GetAllQuestionQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        }
    );

    return Results.Ok(questions);
}).RequireAuthorization();


//Teacher
app.MapPost("/teachers", async (CreateTeacherCommand command, IMediator mediator) =>
{
    var questionId = await mediator.Send(command);
    return Results.Created($"/teachers/{questionId}", questionId);
}).RequireAuthorization(x => x.RequireRole("Teacher"));

//Class
app.MapGet("/Classes", async (int pageNumber, int pageSize, IMediator mediator) =>
{
    var classes = await mediator.Send(new GetAllSchoolClassQuery { PageNumber = pageNumber, PageSize = pageSize });
    return classes is not null ? Results.Ok(classes) : Results.NotFound();
}).RequireAuthorization();


//Exam
app.MapPost("/exams", async (CreateExamCommand command, IMediator mediator) =>
{
    Console.WriteLine("test");
    var examId = await mediator.Send(command);
    return Results.Created($"/questions/{examId}", examId);
}).RequireAuthorization();

app.MapGet("/exams/{id}", async (Guid id, IMediator mediator) =>
{
    var exam = await mediator.Send(new GetExamByIdQuery(id));
    return exam is not null ? Results.Ok(exam) : Results.NotFound();
}).RequireAuthorization();

app.MapGet("/exams", async (int pageNumber, int pageSize, IMediator mediator) =>
{
    var exams = await mediator.Send(new GetAllExamQuery { PageNumber = pageNumber, PageSize = pageSize });
    return exams is not null ? Results.Ok(exams) : Results.NotFound();
}).RequireAuthorization();

app.MapDelete("/exams/{id}", async (Guid id, IMediator mediator) =>
{
    var result = await mediator.Send(new DeleteExamCommand(id));

    return result ? Results.NoContent() : Results.NotFound();
}).RequireAuthorization(x => x.RequireRole("Teacher"));

app.MapPost("/exams/{examId}/submit", async (Guid examId, SubmitStudentExamRequest request, IMediator mediator) =>
{
    var command = new CreateStudentExamAnswerCommand(
       examId,
       request.studentId,
       request.answers
   );

    var isSubmitted = await mediator.Send(command);
    return Results.Ok(isSubmitted);
}).RequireAuthorization(x => x.RequireRole("Student")); 

app.Run();

//public record ExamSubmission(int Id, string StudentId, string Content);