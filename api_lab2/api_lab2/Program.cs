
using api_lab2.MapperConfig;
using api_lab2.Models;
using api_lab2.Repository;
using api_lab2.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace api_lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddDbContext<applicationDBcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("mycon")));

            //CORS service
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    // builder.WithOrigins("ht tps://localhost:7085");
                    //builder.WithMethods("Post","get");
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });


            //builder.Services.AddScoped<StudenstRepo>();
            //builder.Services.AddScoped<DepartmentRepo>();
            builder.Services.AddScoped<GenericRepo<Student>>();
            builder.Services.AddScoped<GenericRepo<Department>>();

            builder.Services.AddScoped<UnitOfWork>();

            builder.Services.AddAutoMapper(typeof(mapconfig)); 

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          



            var app = builder.Build();

           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            

            //app.UseHttpsRedirection();

            app.UseCors("AllowAll");  

            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
