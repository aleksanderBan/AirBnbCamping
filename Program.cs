using AirBnbAPI.Data;

namespace AirBnbAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost8080", builder =>
                {
                    builder.WithOrigins("http://localhost:8080")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddSingleton(typeof(IAnonymousAirBnbDataContext), typeof(AnonymousAirBnbDatabase));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Enable CORS
            app.UseCors("AllowLocalhost8080");

            app.MapControllers();

            app.Run();
        }
    }
}