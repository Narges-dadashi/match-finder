namespace api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        #region MongoDbSettings
        services.Configure<MyMongoDbSettings>(configuration.GetSection(nameof(MyMongoDbSettings)));

        services.AddSingleton<IMyMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MyMongoDbSettings>>().Value);

        services.AddSingleton<IMongoClient>(serviceProvider =>
        {
            MyMongoDbSettings uri = serviceProvider.GetRequiredService<IOptions<MyMongoDbSettings>>().Value;

            return new MongoClient(uri.ConnectionString);
        });
        #endregion MongoDbSettings

        #region Cors: baraye ta'eede Angular HttpClient requests
        services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            });
        #endregion Cors

        #region Other

        services.AddScoped<LogUserActivity>();

        #endregion Other

        return services;
    }
}