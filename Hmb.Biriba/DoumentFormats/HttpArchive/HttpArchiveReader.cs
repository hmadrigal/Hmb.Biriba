using Hmb.Biriba.FileSystem;
using Hmb.Biriba.Models;
using Hmb.Biriba.Serialization;

namespace Hmb.Biriba.DocumentFormats.HttpArchive;

public class HttpArchiveReader
{
    private readonly JsonSerialization _jsonSerialization;

    public HttpArchiveReader(JsonSerialization jsonSerialization)
    {
        _jsonSerialization = jsonSerialization;
    }

    public async IAsyncEnumerable<ParametricRequest> GetParametricRequestsAsync(Stream fileStream)
    {
        var harDocument = await _jsonSerialization.DeserializeAsync<HarDocument>(fileStream);
        if (harDocument?.log?.entries is null)
        {
            yield break;
        }

        for (int i = 0; i < harDocument.log.entries.Length; i++)
        {
            Entry entry = harDocument.log.entries[i];
            ParametricRequest parametricRequest = new ParametricRequest();
            parametricRequest.Method = entry.request?.method;
            parametricRequest.Uri = entry.request?.url;
            parametricRequest.Version = entry.request?.httpVersion;

            if (entry.request?.headers is not null)
            {
                foreach (Header header in entry.request.headers)
                {
                    parametricRequest.Headers.Add(header.name, header.value);
                }
            }

            if (entry.request?.postData is not null)
            {
                ParametricContent parametricContent = new ParametricContent();
                parametricContent.MediaType = entry.request.postData?.mimeType;
                parametricContent.Content = entry.request.postData?.text;
                parametricRequest.Content = parametricContent;
            }

            if (entry.request?.queryString is not null)
            {
                foreach (QueryString queryString in entry.request.queryString)
                {
                    parametricRequest.QueryString.Add(queryString.name, queryString.value);
                }
            }

            yield return parametricRequest;
        }
    }

}
