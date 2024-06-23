
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.NewFolder;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Register Mongodb
            builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("DatabaseSettings"));
            builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")));
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddControllers();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
