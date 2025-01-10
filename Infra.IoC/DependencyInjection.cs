using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Ingest.Elasticsearch;
using Elastic.Serilog.Sinks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly);

            services.AddHealthChecks()
                .AddElasticsearch("http://elasticsearch:9200", "elasticsearch");

            return services;
        }
        public static IHostBuilder ConfigureLog(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, configuration) =>
            {
                configuration
                .WriteTo
                .Elasticsearch(new[] { new Uri("http://elasticsearch:9200") }, opts =>
                {
                    opts.DataStream = new DataStreamName("logs-api", "logs", "webapi");
                    opts.BootstrapMethod = BootstrapMethod.Failure;
                })
                .ReadFrom
                .Configuration(context.Configuration);
            });
            return hostBuilder;
        }
        public static IApplicationBuilder ConfigureHealthCheck(this IApplicationBuilder builder)
        {
            builder.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = HealthChecks.UI.Client.UIResponseWriter.WriteHealthCheckUIResponse
            });
            return builder;
        }
    }
}
