
using CRUDApplication.BL;
using CRUDApplication.DAL;

namespace CRUDApplication.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDataAccessServices(builder.Configuration);

            builder.Services.AddBusinessServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS
            // In your CORS configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    builder =>
                    {
                        builder.SetIsOriginAllowed(origin => true)
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });



            var app = builder.Build();


            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAngularApp",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4200")
            //                   .AllowAnyMethod()
            //                   .AllowAnyHeader()
            //                   .AllowCredentials();
            //        });
            //});

            //var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngularApp");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
