using Hmb.Biriba.FileSystem;
using Hmb.Biriba.Scanner;
using Hmb.Biriba.Serialization;
using Hmb.Biriba.SpecFormats;
using Hmb.Biriba.SpecFormats.HttpArchiveV1_2;
using Hmb.Biriba.SpecFormats.PostmanV2_1_0;
using Microsoft.Extensions.DependencyInjection;

namespace Hmb.Biriba;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBiriba(this IServiceCollection services)
    {

        services.AddSingleton<FileReader>();
        services.AddSingleton<VulnerabilityScanner>();
        services.AddSingleton<JsonSerialization>();

        services.AddSingleton<ISpecFormatReader, HttpArchiveReader>();
        services.AddSingleton<ISpecFormatReader, PostmanCollectionReader>();

        return services;
    }
}
