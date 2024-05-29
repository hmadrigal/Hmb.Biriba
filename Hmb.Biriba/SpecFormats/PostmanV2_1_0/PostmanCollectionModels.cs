using System.Text.Json.Serialization;
using System.Text.Json;

namespace Hmb.Biriba.SpecFormats.PostmanV2_1_0
{

    public record PostmanCollectionDocument
    {
        [JsonPropertyName("info")]
        public Information Information { get; init; }

        [JsonConverter(typeof(ItemArrayJsonConverter))]
        [JsonPropertyName("item")]
        public Item[] Items { get; init; }

        [JsonPropertyName("event")]
        public Event[] Event { get; init; }

        [JsonPropertyName("variable")]
        public Variable[] Variable { get; init; }

        [JsonPropertyName("auth")]
        public Authentication? Authentication { get; init; }

        [JsonPropertyName("protocolProfileBehavior")]
        public ProtocolProfileBehavior? ProtocolProfileBehavior { get; init; }
    }

    /// <summary>
    /// Detailed description of the info block
    /// </summary>
    public record Information
    {
        /// <summary>
        /// A collection's friendly name is defined by this field. You would want to set this field to a value that would allow you to easily identify this collection among a bunch of other collections, as such outlining its usage or content.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }

        /// <summary>
        /// Every collection is identified by the unique value of this field. The value of this field is usually easiest to generate using a UID generator function. If you already have a collection, it is recommended that you maintain the same id since changing the id usually implies that is a different collection than it was originally.
        /// </summary>
        /// <remarks> Note: This field exists for compatibility reasons with Collection Format V1. </remarks>
        [JsonPropertyName("_postman_id")]
        public string? PostmanId { get; init; }

        /// <summary>
        /// This should ideally hold a link to the Postman schema that is used to validate this collection. E.g: https://schema.getpostman.com/collection/v1
        /// </summary>
        [JsonPropertyName("schema")]
        public string Schema { get; init; }

        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }

        [JsonConverter(typeof(VersionJsonConverter))]
        [JsonPropertyName("version")]
        public Version? Version { get; init; }
    }

    public record Item
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }

        [JsonPropertyName("variable")]
        public Variable[]? Variable { get; init; }

        [JsonPropertyName("event")]
        public Event[]? Event { get; init; }

        [JsonPropertyName("protocolProfileBehavior")]
        public ProtocolProfileBehavior? ProtocolProfileBehavior { get; init; }

        #region FolderItem
        [JsonConverter(typeof(ItemArrayJsonConverter))]
        [JsonPropertyName("item")]
        public Item[]? Items { get; init; }

        [JsonPropertyName("auth")]
        public Authentication[]? Authentication { get; init; }
        #endregion

        #region RequestItem
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        [JsonConverter(typeof(RequestJsonConverter))]
        [JsonPropertyName("request")]
        public Request Request { get; init; }

        //[JsonPropertyName("response")]
        //public Response[]? Response { get; init; }
        #endregion
    }


    //public record Response
    //{
    //    [JsonPropertyName("id")]
    //    public string? Id { get; init; }

    //    //[JsonPropertyName("originalRequest")]
    //    //public Request? OriginalRequest { get; init; }
    //    //responseTime
    //    //timings
    //    //header
    //    //cookie
    //    //body
    //    //status
    //    //code
    //}

    public record Request
    {
        [JsonPropertyName("method")]
        public string? Method { get; init; }

        [JsonConverter(typeof(SourceUriJsonConvert))]
        [JsonPropertyName("url")]
        public SourceUri? Url { get; init; }

        // auth
        // proxy
        // certificate
        // description
        // header
        // body
    }

    /// <summary>
    /// Set of configurations used to alter the usual behavior of sending the request
    /// </summary>
    public record ProtocolProfileBehavior
    {
        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; init; }

    }

    public record Description
    {
        [JsonPropertyName("content")]
        public string? Content { get; init; }
        [JsonPropertyName("type")]
        public string? Type { get; init; }
        [JsonPropertyName("version")]
        public string? Version { get; init; }
    }

    public record Version
    {
        [JsonPropertyName("major")]
        public long Major { get; init; }
        [JsonPropertyName("minor")]
        public long Minor { get; init; }
        [JsonPropertyName("patch")]
        public long Patch { get; init; }
        [JsonPropertyName("identifier")]
        public string? Identifier { get; init; }
        [JsonPropertyName("meta")]
        public string? Meta { get; init; }
    }

    public record Meta
    {
        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; init; }
    }

    public record Event
    {
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        [JsonPropertyName("listen")]
        public string Listen { get; init; }

        [JsonPropertyName("script")]
        public Script Script { get; init; }
    }

    public record Script
    {
        [JsonPropertyName("id")]
        public string? Id { get; init; }
        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("name")]
        public string? Name { get; init; }

        [JsonConverter(typeof(StringArrayJsonConverter))]
        [JsonPropertyName("exec")]
        public string[] ExecutableLines { get; init; }

        [JsonConverter(typeof(SourceUriJsonConvert))]
        [JsonPropertyName("src")]
        public SourceUri? Source { get; init; }
    }

    public record SourceUri
    {
        [JsonPropertyName("raw")]
        public string? Raw { get; init; }

        [JsonPropertyName("protocol")]
        public string? Protocol { get; init; }

        [JsonConverter(typeof(DotSeparatedStringArrayJsonConverter))]
        [JsonPropertyName("host")]
        public string[]? Host { get; init; }

        [JsonPropertyName("port")]
        public string? Port { get; init; }

        [JsonConverter(typeof(SlashSeparatedStringArrayJsonConverter))]
        [JsonPropertyName("path")]
        public string[]? Path { get; init; }

        [JsonPropertyName("query")]
        public QueryParam[]? Query { get; init; }

        [JsonPropertyName("hash")]
        public string? Hash { get; init; }

        [JsonPropertyName("variable")]
        public Variable[]? Variable { get; init; }
    }



    public record QueryParam
    {
        [JsonPropertyName("key")]
        public string? Key { get; init; }
        [JsonPropertyName("value")]
        public string? Value { get; init; }
        [JsonPropertyName("disabled")]
        public bool Disabled { get; init; }
        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }
    }

    public record Variable
    {
        [JsonPropertyName("id")]
        public string? Id { get; init; }
        [JsonPropertyName("key")]
        public string? Key { get; init; }
        [JsonPropertyName("value")]
        public string? Value { get; init; }
        [JsonPropertyName("type")]
        public string? Type { get; init; }
        [JsonPropertyName("name")]
        public string? Name { get; init; }
        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }
        [JsonPropertyName("system")]
        public bool? System { get; init; }
        [JsonPropertyName("disabled")]
        public bool? Disabled { get; init; }
    }

    public record KeyValueType
    {
        [JsonPropertyName("key")]
        public string Key { get; init; }
        [JsonPropertyName("value")]
        public string? Value { get; init; }
        [JsonPropertyName("type")]
        public string? Type { get; init; }
    }

    /// <summary>
    /// Represents authentication helpers provided by Postman
    /// </summary>
    public record Authentication
    {
        [JsonPropertyName("type")]
        public string? Type { get; init; }

        [JsonPropertyName("noauth")]
        public NoAuth? NoAuth { get; init; }

        [JsonPropertyName("apikey")]
        public KeyValueType[]? ApiKey { get; init; }
        [JsonPropertyName("awsv4")]
        public KeyValueType[]? AwsV4 { get; init; }
        [JsonPropertyName("basic")]
        public KeyValueType[]? Basic { get; init; }
        [JsonPropertyName("bearer")]
        public KeyValueType[]? Bearer { get; init; }
        [JsonPropertyName("digest")]
        public KeyValueType[]? Digest { get; init; }
        [JsonPropertyName("edgegrid")]
        public KeyValueType[]? EdgeGrid { get; init; }
        [JsonPropertyName("hawk")]
        public KeyValueType[]? Hawk { get; init; }
        [JsonPropertyName("ntlm")]
        public KeyValueType[]? Ntlm { get; init; }
        [JsonPropertyName("oauth1")]
        public KeyValueType[]? OAuth1 { get; init; }
        [JsonPropertyName("oauth2")]
        public KeyValueType[]? OAuth2 { get; init; }
    }

    public record NoAuth
    {
        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; init; }
    }

}