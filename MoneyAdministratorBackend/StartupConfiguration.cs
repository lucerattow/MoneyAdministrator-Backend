namespace MoneyAdministratorBackend
{
    public class StartupConfiguration
    {
        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowLocalhost3000");
            app.UseHttpsRedirection();
            app.UseAuthentication(); //JWT
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
