using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hmb.Biriba.SpecFormats.PostmanV2_1_0
{
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
            throw new NotImplementedException();
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
}
