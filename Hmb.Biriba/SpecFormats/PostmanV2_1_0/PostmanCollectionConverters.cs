using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace Hmb.Biriba.SpecFormats.PostmanV2_1_0
{
    internal class JsonConvertUtils
    {
        internal static SourceUri CreateSourceUriFromRaw(string? raw)
        {
            Uri.TryCreate(raw, UriKind.Absolute, out Uri? uri);
            NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(uri?.Query ?? string.Empty);

            var queryParams = (from key in queryStringCollection.AllKeys
                               from value in queryStringCollection.GetValues(key) ?? []
                               select new QueryParam { Key = key, Value = value }).ToArray();

            if (queryParams.Length == 0)
            {
                queryParams = null;
            }
            SourceUri sourceUri = new SourceUri { Raw = raw, Protocol = uri?.Scheme, Port = uri?.Port.ToString(), Query = queryParams, Hash = uri?.Fragment };
            return sourceUri;
        }
    }
    public class DescriptionJsonConverter : JsonConverter<Description>
    {
        public override Description? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new Description { Content = reader.GetString() };
            }
            else
            {
                return JsonSerializer.Deserialize<Description>(ref reader, options);
            }
        }

        public override void Write(Utf8JsonWriter writer, Description value, JsonSerializerOptions options)
        {
            if (value is null || value.Type is not null || value.Version is not null)
            {
                JsonSerializer.Serialize(writer, value, options);
            }
            else
            {
                writer.WriteStringValue(value.Content);
            }
        }
    }

    public class VersionJsonConverter : JsonConverter<Version>
    {
        public override Version? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                return JsonSerializer.Deserialize<Version>(ref reader, options);
            }
            var versionString = reader.GetString();
            if (versionString == null)
            {
                return null;
            }
            const string pattern = @"^(\d+)\.(\d+)\.(\d+)(?:-([0-9A-Za-z.-]+))?(?:\+([0-9A-Za-z.-]+))?$";
            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(versionString, pattern);

            string major = match.Groups[1].Value;
            string minor = match.Groups[2].Value;
            string patch = match.Groups[3].Value;
            string? identifier = match.Groups[4].Value;  // This will be empty if not present
            string? meta = match.Groups[5].Value;        // This will be empty if not present

            return new Version { Major = long.Parse(major), Minor = long.Parse(minor), Patch = long.Parse(patch), Identifier = identifier, Meta = meta };

        }

        public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
        {

            if (value is null || value.Identifier is not null || value.Meta is not null)
            {
                JsonSerializer.Serialize(writer, value, options);
            }
            else
            {
                if (value.Identifier is not null && value.Meta is not null)
                {
                    writer.WriteStringValue($"{value.Major}.{value.Minor}.{value.Patch}-{value.Identifier}+{value.Meta}");
                }
                else if (value.Identifier is not null)
                {
                    writer.WriteStringValue($"{value.Major}.{value.Minor}.{value.Patch}-{value.Identifier}");
                }
                else if (value.Meta is not null)
                {
                    writer.WriteStringValue($"{value.Major}.{value.Minor}.{value.Patch}+{value.Meta}");
                }
                else
                {
                    writer.WriteStringValue($"{value.Major}.{value.Minor}.{value.Patch}");
                }
            }
        }
    }

    public class RequestJsonConverter : JsonConverter<Request>
    {
        public override Request? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new Request { Method = HttpMethods.GET, Url = JsonConvertUtils.CreateSourceUriFromRaw(reader.GetString()) };
            }
            else
            {
                return JsonSerializer.Deserialize<Request>(ref reader, options);
            }
        }

        public override void Write(Utf8JsonWriter writer, Request value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemArrayJsonConverter : JsonConverter<Item[]>
    {
        public override Item[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                Item? item = JsonSerializer.Deserialize<Item>(ref reader, options);
                return item is null ? [] : [item];
            }
            return JsonSerializer.Deserialize<Item[]?>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, Item[] value, JsonSerializerOptions options)
        {
            if (value is null || value.Length > 1)
            {
                JsonSerializer.Serialize<Item[]?>(writer, value, options);
            }
            else
            {
                JsonSerializer.Serialize<Item?>(writer, value[0], options);
            }
        }
    }

    public class StringArrayJsonConverter : JsonConverter<string[]>
    {
        public override string[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string? value = reader.GetString();
                return GenerateStringArray(value);
            }
            return JsonSerializer.Deserialize<string[]?>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, string[] value, JsonSerializerOptions options)
        {
            if (IsMultipleStrings(value))
            {
                JsonSerializer.Serialize<string[]?>(writer, value, options);
            }
            else
            {
                JsonSerializer.Serialize<string?>(writer, value[0], options);
            }
        }

        protected virtual bool IsMultipleStrings(string[] value)
        {
            return value is null || value.Length > 1;
        }

        protected virtual string[] GenerateStringArray(string? value)
        {
            return value is null ? [] : [value];
        }
    }

    public abstract class CharSeparatedStringArrayJsonConverter : StringArrayJsonConverter
    {
        public abstract char Separator { get; }

        protected override bool IsMultipleStrings(string[] value)
        {
            return value is not null && ((value.Length == 1 && value[0].Contains(Separator)) || value.Length > 1) ;
        }

        protected override string[] GenerateStringArray(string? value)
        {
            return value is null ? [] : value.Split(Separator);
        }
    }

    public class DotSeparatedStringArrayJsonConverter : CharSeparatedStringArrayJsonConverter
    {
        public override char Separator => '.';
    }

    public class SlashSeparatedStringArrayJsonConverter : CharSeparatedStringArrayJsonConverter
    {
        public override char Separator => '/';
    }

    public class SourceUriJsonConvert : JsonConverter<SourceUri>
    {
        public override SourceUri? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return JsonConvertUtils.CreateSourceUriFromRaw(reader.GetString());
            }
            else
            {
                return JsonSerializer.Deserialize<SourceUri>(ref reader, options);
            }
        }

        public override void Write(Utf8JsonWriter writer, SourceUri value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

}
