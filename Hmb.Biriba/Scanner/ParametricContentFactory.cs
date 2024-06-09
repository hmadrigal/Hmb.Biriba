using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hmb.Biriba.Scanner;

public class ParametricContentFactory
{
    public static ParametricContent Create(string? mediaType, string? content, IDictionary<string, string>? headers)
    {
        // Lets assume good faith and that the media type really represents the content.
        // https://www.iana.org/assignments/media-types/media-types.xhtml
        if (!MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType) || parsedMediaType.MediaType is null)
        {
            return new ParametricContent
            {
                MediaType = mediaType,
                Content = content,
                Headers = headers
            };
        }

        if (parsedMediaType.MediaType.EndsWith("+xml", StringComparison.OrdinalIgnoreCase)
            || parsedMediaType.MediaType.EndsWith("/xml", StringComparison.OrdinalIgnoreCase))
        {
            return new ParametricXmlContent
            {
                MediaType = mediaType,
                Content = content,
                Headers = headers
            };
        }
        else if (parsedMediaType.MediaType.EndsWith("+json", StringComparison.OrdinalIgnoreCase)
            || parsedMediaType.MediaType.EndsWith("/json", StringComparison.OrdinalIgnoreCase))
        {
            return new ParametricJsonContent
            {
                MediaType = mediaType,
                Content = content,
                Headers = headers
            };
        }
        else if (parsedMediaType.MediaType.EndsWith("+graphql", StringComparison.OrdinalIgnoreCase)
            || parsedMediaType.MediaType.EndsWith("/graphql", StringComparison.OrdinalIgnoreCase))
        {
            return new ParametricGraphQlContent
            {
                MediaType = mediaType,
                Content = content,
                Headers = headers
            };
        }
        else if (parsedMediaType.MediaType.EndsWith("/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
        {
            return new ParametricUrlEncodedContent
            {
                MediaType = mediaType,
                Content = content,
                Headers = headers
            };
        }
        else if (parsedMediaType.MediaType.EndsWith("/form-data", StringComparison.OrdinalIgnoreCase))
        {
            return new ParametricFormDataContent
            {
                MediaType = mediaType,
                Content = content,
                Headers = headers
            };
        }


        return new ParametricContent
        {
            MediaType = mediaType,
            Content = content,
            Headers = headers
        };
    }


}
