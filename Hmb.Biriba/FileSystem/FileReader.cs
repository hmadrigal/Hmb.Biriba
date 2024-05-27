using System.Diagnostics.CodeAnalysis;

namespace Hmb.Biriba.FileSystem
{
    public class FileReader
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public FileReader(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<Stream> GetStreamAsync(string path)
        {
            ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));

            if (!Uri.TryCreate(path, UriKind.Absolute, out var uri))
            {
                return GetStreamFromLocalFileAsync(path);
            }

            if (uri.Scheme.StartsWith(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase))
            {
                return GetStreamFromRemoteHttpFileAsync(path);
            }

            throw new NotSupportedException($"The scheme '{uri.Scheme}' is not supported.");
        }

        public Task<Stream> GetStreamFromRemoteHttpFileAsync([StringSyntax(StringSyntaxAttribute.Uri)] string path)
            => _httpClientFactory.CreateClient().GetStreamAsync(path);

        public Task<Stream> GetStreamFromLocalFileAsync(string path)
            => Task.FromResult<Stream>(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous));

    }
}
