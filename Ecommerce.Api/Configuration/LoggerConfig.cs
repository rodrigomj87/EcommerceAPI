using Ecommerce.Api.Extensions;

namespace Ecommerce.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "4771aa5d21904b9fa03ac157ccd6334b";
                o.LogId = new Guid("fa5a7e36-4cfd-4d67-b658-b01efdc66360");
            });

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "4771aa5d21904b9fa03ac157ccd6334b";
                    options.LogId = new Guid("fa5a7e36-4cfd-4d67-b658-b01efdc66360");
                    options.HeartbeatId = "3be5d881d80a4f268e3e10d72854a05e";

                })
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "Ecommerce");

            services.AddHealthChecksUI()
                .AddSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}