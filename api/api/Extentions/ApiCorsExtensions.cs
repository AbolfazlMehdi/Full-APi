public static class ApiCorsExtensions
{
    public static void UseAPiCors(this IApplicationBuilder applicationBuilder, IConfiguration configuration)
    {
        applicationBuilder.UseCors(builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod();
             
        });
    }
}
