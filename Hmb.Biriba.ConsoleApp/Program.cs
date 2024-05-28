// See https://aka.ms/new-console-template for more information
using Hmb.Biriba.SpecFormats.HttpArchiveV1_2;
using Hmb.Biriba.FileSystem;
using Hmb.Biriba.Models;
using Hmb.Biriba.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Hmb.Biriba.SpecFormats.PostmanV2_1_0;


ServiceCollection services = new ServiceCollection();
services.AddHttpClient();
services.AddSingleton<FileReader>();
services.AddSingleton<HttpArchiveReader>();
services.AddSingleton<PostmanCollectionReader>();
services.AddSingleton<JsonSerialization>();
IServiceProvider serviceProvider = services.BuildServiceProvider();

FileReader fileReader = serviceProvider.GetRequiredService<FileReader>();

////string harFile = @"https://raw.githubusercontent.com/okta/okta-sdk-test-server/master/scenarios/user-change-password.har";
////string harFile = @"https://raw.githubusercontent.com/tetreum/clicktrade-etf/main/insomnia_request.har";
//string harFile = @"C:\Users\hfmad\Downloads\sistemas.inec.cr.har";
//using Stream harFileStream = await fileReader.GetStreamAsync(harFile);
//HttpArchiveReader httpArchiveReader = serviceProvider.GetRequiredService<HttpArchiveReader>();
//await foreach (ParametricRequest parametricRequest in httpArchiveReader.GetParametricRequestsAsync(harFileStream))
//{
//    Console.WriteLine(parametricRequest);
//}

//string postmanFile = @"C:\Users\hfmad\Downloads\working-with-graphql.postman_collection.json";
//string postmanFile = @"https://raw.githubusercontent.com/Blazemeter/taurus/master/examples/functional/postman-sample-collection.json";
//string postmanFile = @"C:\Users\hfmad\Downloads\VehicleRegistrationAPI.com.postman_collection.json";
string postmanFile = @"C:\Users\hfmad\Downloads\api-documentation-reference.postman_collection.json";
using Stream postmanFileStream = await fileReader.GetStreamAsync(postmanFile);
PostmanCollectionReader postmanCollectionReader = serviceProvider.GetRequiredService<PostmanCollectionReader>();
await foreach (ParametricRequest parametricRequest in postmanCollectionReader.GetParametricRequestsAsync(postmanFileStream))
{
    Console.WriteLine(parametricRequest);
}

Console.WriteLine("Press ESC to exit");
while (Console.ReadKey().Key != ConsoleKey.Escape) ;