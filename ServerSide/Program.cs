namespace ServerSide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(opt => opt.AddPolicy(name: "myPolicy", policy =>
            {
                policy.AllowAnyOrigin() // אפשר לכל המקורות
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("myPolicy"); // שימוש ב-CORS policy "myPolicy"

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
