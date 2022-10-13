global using library_management_system.Models;
using library_management_system.Data;

using library_management_system.Data.AuthorRepository;
using library_management_system.Data.BookRepository;
using library_management_system.Data.CategoryRepository;
using library_management_system.Data.MemberRepository;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using library_management_system.Services.AuthorService;
using library_management_system.Services.BookService;
using library_management_system.Services.CategoryService;
using library_management_system.Services.MemberService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repos
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

// Services
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMemberService, MemberService>();

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
