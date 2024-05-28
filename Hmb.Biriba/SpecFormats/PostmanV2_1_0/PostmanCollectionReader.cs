using Hmb.Biriba.Models;
using Hmb.Biriba.Serialization;

namespace Hmb.Biriba.SpecFormats.PostmanV2_1_0;

public class PostmanCollectionReader
{
    private readonly JsonSerialization _jsonSerialization;

    public PostmanCollectionReader(JsonSerialization jsonSerialization)
    {
        _jsonSerialization = jsonSerialization;
    }

    public async IAsyncEnumerable<ParametricRequest> GetParametricRequestsAsync(Stream fileStream)
    {
        var postmanDocument = await _jsonSerialization.DeserializeAsync<PostmanCollectionDocument>(fileStream);
        yield break;
    }
}
