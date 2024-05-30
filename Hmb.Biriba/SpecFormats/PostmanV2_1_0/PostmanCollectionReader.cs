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
        PostmanCollectionDocument? postmanDocument = await _jsonSerialization.DeserializeAsync<PostmanCollectionDocument>(fileStream);

        if (postmanDocument?.Items is null || postmanDocument.Items.Length == 0)
        {
            yield break;
        }
        static IEnumerable<Item> GetAllItems(params Item[] items)
        {
            foreach (Item item in items)
            {
                if (item.Items is null)
                {
                    yield return item;
                }
                else
                {
                    foreach (Item nestedItem in item.Items)
                    {
                        foreach (Item subItem in GetAllItems(nestedItem))
                        {
                            yield return subItem;
                        }
                    }
                }
            }

        }

        foreach (Item item in GetAllItems(postmanDocument.Items))
        {
            if (item.Request is null)
            {
                continue;
            }

            ParametricRequest parametricRequest = new ParametricRequest();
            parametricRequest.Method = item.Request.Method.ToString();
            parametricRequest.Uri = item.Request.Url?.Raw;
            if (item.Request?.Headers is not null)
            {
                foreach (Header header in item.Request.Headers)
                {
                    parametricRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (item.Request?.Body is not null)
            {
                ParametricContent parametricContent = new ParametricContent();
                if (item.Request.Body.Raw is not null && item.Request.Body.Mode == BodyMode.raw)
                {
                    parametricContent.Content = item.Request.Body.Raw;
                }
                else if (item.Request.Body.UrlEncoded is not null && item.Request.Body.Mode == BodyMode.urlencoded)
                {
                    parametricContent.MediaType = "application/x-www-form-urlencoded";
                    //parametricContent.Content = item.Request.Body.UrlEncoded;
                }
                else if (item.Request.Body.FormData is not null && item.Request.Body.Mode == BodyMode.formdata)
                {
                    parametricContent.MediaType = "multipart/form-data";
                    //parametricContent.Content = item.Request.Body.FormData;
                }
                else if (item.Request.Body.File is not null && item.Request.Body.Mode == BodyMode.file)
                {
                    parametricContent.MediaType = "application/octet-stream";
                    //parametricContent.Content = item.Request.Body.File;
                }
                else if (item.Request.Body.GraphQl is not null && item.Request.Body.Mode == BodyMode.graphql)
                {
                    // https://graphql.github.io/graphql-over-http/draft/#sec-Media-Types
                    // application/graphql | application/json | application/graphql-response+json 
                    parametricContent.MediaType = "application/graphql";
                    //parametricContent.Content = item.Request.Body.GraphQl;
                }


            }

            yield return parametricRequest;
        }

    }
}
