// See https://aka.ms/new-console-template for more information
using Hmb.Biriba.SpecFormats.HttpArchiveV1_2;
using Hmb.Biriba.FileSystem;
using Hmb.Biriba.Models;
using Hmb.Biriba.Serialization;
using Microsoft.Extensions.DependencyInjection;


ServiceCollection services = new ServiceCollection();
services.AddHttpClient();
services.AddSingleton<FileReader>();
services.AddSingleton<HttpArchiveReader>();
services.AddSingleton<JsonSerialization>(); 
IServiceProvider serviceProvider = services.BuildServiceProvider();

//string url = @"https://raw.githubusercontent.com/okta/okta-sdk-test-server/master/scenarios/user-change-password.har";
//string url = @"https://raw.githubusercontent.com/tetreum/clicktrade-etf/main/insomnia_request.har";
string url = @"C:\Users\hfmad\Downloads\sistemas.inec.cr.har";
FileReader fileReader = serviceProvider.GetRequiredService<FileReader>();
using Stream fileStream = await fileReader.GetStreamAsync(url);
HttpArchiveReader httpArchiveReader = serviceProvider.GetRequiredService<HttpArchiveReader>();

await foreach (ParametricRequest parametricRequest in httpArchiveReader.GetParametricRequestsAsync(fileStream))
{
    Console.WriteLine(parametricRequest);
}

Console.WriteLine("Press ESC to exit");
while (Console.ReadKey().Key != ConsoleKey.Escape) ;