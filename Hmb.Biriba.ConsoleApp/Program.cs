using Hmb.Biriba;
using Hmb.Biriba.ConsoleApp;
using Hmb.Biriba.ConsoleApp.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using System.Reflection;


var runner = BuildCommandLine()
    .UseHost(
        hostBuilderFactory: _ => Host.CreateDefaultBuilder(args),
        configureHost: (builder) =>
        {
            builder
                .UseEnvironment("CLI")
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddBiriba();
                    services.AddCli();
                    services.AddHttpClient();
                    services.AddSerilog();
                    services.AddMediatR(config =>
                    {
                        config.RegisterServicesFromAssemblies(
                            Assembly.GetExecutingAssembly(),
                            typeof(Hmb.Biriba.ServiceCollectionExtensions).Assembly
                        );
                    });
                })
                .UseCommandHandler<RunScannerCommand, RunScannerCommand.Handler>();
        })
    .UseDefaults()
    .Build();

return await runner.InvokeAsync(args);

static CommandLineBuilder BuildCommandLine()
{
    var root = new ApplicationRootCommand();
    root.AddCommand(BuildScannerCommands());

    return new CommandLineBuilder(root);

    static Command BuildScannerCommands()
    {
        var scannerCommands = new Command("scanner", "Scanner actions")
        {
            new RunScannerCommand(), 
        };
        return scannerCommands;
    }
}


#region
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Configuration;

//var hostBuilder = new HostBuilder();

//hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile("appsettings.json", optional: true);
//    config.AddEnvironmentVariables();
//    config.AddCommandLine(args);
//});

//hostBuilder.ConfigureServices((hostContext, services) =>
//{
//    //services.AddHttpClient();
//    //services.AddSingleton<FileReader>();
//    //services.AddSingleton<HttpArchiveReader>();
//    //services.AddSingleton<PostmanCollectionReader>();
//    //services.AddSingleton<JsonSerialization>();
//    //services.AddSingleton < ParametricRequestScanner
//});


//using IHost host = hostBuilder.Build();
//var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

//lifetime.ApplicationStarted.Register(() =>
//{
//    Console.WriteLine("Started");
//});
//lifetime.ApplicationStopping.Register(() =>
//{
//    Console.WriteLine("Stopping firing");
//    Console.WriteLine("Stopping end");
//});
//lifetime.ApplicationStopped.Register(() =>
//{
//    Console.WriteLine("Stopped firing");
//    Console.WriteLine("Stopped end");
//});

//host.Start();

//// Listens for Ctrl+C.
//host.WaitForShutdown(); 
#endregion


#region

//// See https://aka.ms/new-console-template for more information
//using Hmb.Biriba.SpecFormats.HttpArchiveV1_2;
//using Hmb.Biriba.FileSystem;
//using Hmb.Biriba.Serialization;
//using Microsoft.Extensions.DependencyInjection;
//using Hmb.Biriba.SpecFormats.PostmanV2_1_0;
//using Hmb.Biriba.Scanner;


//ServiceCollection services = new ServiceCollection();
//services.AddHttpClient();
//services.AddSingleton<FileReader>();
//services.AddSingleton<HttpArchiveReader>();
//services.AddSingleton<PostmanCollectionReader>();
//services.AddSingleton<JsonSerialization>();
//IServiceProvider serviceProvider = services.BuildServiceProvider();

//FileReader fileReader = serviceProvider.GetRequiredService<FileReader>();

//////string harFile = @"https://raw.githubusercontent.com/okta/okta-sdk-test-server/master/scenarios/user-change-password.har";
//////string harFile = @"https://raw.githubusercontent.com/tetreum/clicktrade-etf/main/insomnia_request.har";
////string harFile = @"C:\Users\hfmad\Downloads\sistemas.inec.cr.har";
////using Stream harFileStream = await fileReader.GetStreamAsync(harFile);
////HttpArchiveReader httpArchiveReader = serviceProvider.GetRequiredService<HttpArchiveReader>();
////await foreach (ParametricRequest parametricRequest in httpArchiveReader.GetParametricRequestsAsync(harFileStream))
////{
////    Console.WriteLine(parametricRequest);
////}

////string postmanFile = @"C:\Users\hfmad\Downloads\working-with-graphql.postman_collection.json";
////string postmanFile = @"https://raw.githubusercontent.com/Blazemeter/taurus/master/examples/functional/postman-sample-collection.json";
////string postmanFile = @"C:\Users\hfmad\Downloads\VehicleRegistrationAPI.com.postman_collection.json";
////string postmanFile = @"C:\Users\hfmad\Downloads\api-documentation-reference.postman_collection.json";
////string postmanFile = @"C:\Users\hfmad\Downloads\multipart-file.postman_collection.json";
//string postmanFile = @"C:\Users\hfmad\Downloads\urlencoded-file.postman_collection.json";
//using Stream postmanFileStream = await fileReader.GetStreamAsync(postmanFile);
//PostmanCollectionReader postmanCollectionReader = serviceProvider.GetRequiredService<PostmanCollectionReader>();
//await foreach (ParametricRequest parametricRequest in postmanCollectionReader.GetParametricRequestsAsync(postmanFileStream))
//{
//    Console.WriteLine(parametricRequest);
//}

//Console.WriteLine("Press ESC to exit");
//while (Console.ReadKey().Key != ConsoleKey.Escape) ; 
#endregion