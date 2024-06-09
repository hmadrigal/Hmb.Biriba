
using Hmb.Biriba.ConsoleApp.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.CommandLine.Parsing;

namespace Hmb.Biriba.ConsoleApp;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCli(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        return services;
    }

    public static IServiceCollection AddSerilog(this IServiceCollection services)
    {
        Serilog.Log.Logger = CreateLogger(services);
        return services;
    }

    private static Serilog.Core.Logger CreateLogger(IServiceCollection services)
    {
        var scope = services.BuildServiceProvider();
        var parseResult = scope.GetRequiredService<ParseResult>();
        var isSilentLogger = true;
        if (parseResult.RootCommandResult.Command is ApplicationRootCommand applicationRootCommand)
        {
            isSilentLogger = parseResult.RootCommandResult.GetValueForOption<bool>(applicationRootCommand.SilentOption);
        }
        var loggerConfiguration = new LoggerConfiguration()
            .ReadFrom.Configuration(scope.GetRequiredService<IConfiguration>());

        if (isSilentLogger)
        {
            loggerConfiguration.MinimumLevel.Override("Biriba", Serilog.Events.LogEventLevel.Warning);
            loggerConfiguration.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning);
        }

        return loggerConfiguration.CreateLogger();
    }

    /// <summary>
    /// NOTE: Pipeline behavior registration order is important.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }

}
