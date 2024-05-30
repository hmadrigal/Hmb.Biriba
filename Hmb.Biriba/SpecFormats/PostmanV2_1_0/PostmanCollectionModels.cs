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

        /// <summary>
        /// A Description can be a raw text, or be an object, which holds the description along with its format.
        /// </summary>
        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }

        /// <summary>
        /// Postman allows you to version your collections as they grow, and this field holds the version number. While optional, it is recommended that you use this field to its fullest extent!
        /// </summary>
        [JsonConverter(typeof(VersionJsonConverter))]
        [JsonPropertyName("version")]
        public Version? Version { get; init; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; init; }
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
        public HttpMethods? Method { get; init; }

        [JsonConverter(typeof(SourceUriJsonConvert))]
        [JsonPropertyName("url")]
        public SourceUri? Url { get; init; }

        [JsonPropertyName("auth")]
        public Authentication? Authentication { get; init; }

        // TODO: implement HeaderJsonConverter
        //[JsonConverter(typeof(HeaderJsonConverter))]
        [JsonPropertyName("header")]
        public Header[]? Headers { get; init; }

        [JsonPropertyName("body")]
        public Body? Body { get; init; }

        // TODO: implement 'proxy' property
        // TODO: implement 'certificate' property

        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter<HttpMethods>))]

    public enum HttpMethods
    {
        GET,
        PUT,
        POST,
        PATCH,
        DELETE,
        COPY,
        HEAD,
        OPTIONS,
        LINK,
        UNLINK,
        PURGE,
        LOCK,
        UNLOCK,
        PROPFIND,
        VIEW
    }

    public record Body
    {
        [JsonPropertyName("mode")]
        public BodyMode? Mode { get; init; }

        [JsonPropertyName("raw")]
        public string? Raw { get; init; }

        [JsonPropertyName("graphql")]
        public string? GraphQl { get; init; }

        [JsonPropertyName("urlencoded")]
        public UrlEncodedParameter[]? UrlEncoded { get; init; }

        [JsonPropertyName("formdata")]
        public FormParameter[]? FormData { get; init; }

        [JsonPropertyName("file")]
        public File? File { get; init; }

        [JsonPropertyName("options")]
        public Options? Options { get; init; }

        [JsonPropertyName("disabled")]
        public bool Disabled { get; init; }

        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter<BodyMode>))]
    public enum BodyMode
    {
        raw,
        urlencoded,
        formdata,
        file,
        graphql
    }

    public record Options
    {
        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; init; }
    }


    public record File
    {
        [JsonPropertyName("src")]
        public string? Source { get; init; }

        [JsonPropertyName("content")]
        public string? Content { get; init; }
    }

    [JsonDerivedType(typeof(FormValueParameter))]
    [JsonDerivedType(typeof(FormFileParameter))]
    public record FormParameter
    {
        [JsonPropertyName("key")]
        public string Key { get; init; }

        [JsonPropertyName("disabled")]
        public bool? Disabled { get; init; }

        [JsonPropertyName("type")]
        public string? Type { get; init; }

        [JsonPropertyName("contentType")]
        public string? ContentType { get; init; }

        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }
    }

    public record FormValueParameter : FormParameter
    {
        [JsonPropertyName("value")]
        public string? Value { get; init; }
    }

    public record FormFileParameter : FormParameter
    {
        [JsonPropertyName("src")]
        public string? Source { get; init; }
    }

    public record UrlEncodedParameter
    {
        [JsonPropertyName("key")]
        public string Key { get; init; }

        [JsonPropertyName("value")]
        public string? Value { get; init; }

        [JsonPropertyName("disabled")]
        public bool? Disabled { get; init; }

        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }
    }

    public record Header
    {
        [JsonPropertyName("key")]
        public string Key { get; init; }

        [JsonPropertyName("value")]
        public string Value { get; init; }

        [JsonPropertyName("disabled")]
        public bool Disabled { get; init; }

        [JsonConverter(typeof(DescriptionJsonConverter))]
        [JsonPropertyName("description")]
        public Description? Description { get; init; }
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
        /// <summary>
        /// The content of the description goes here, as a raw string
        /// </summary>
        [JsonPropertyName("content")]
        public string? Content { get; init; }

        /// <summary>
        /// Holds the mime type of the raw description content. E.g: 'text/markdown' or 'text/html'.
        /// The type is used to correctly render the description when generating documentation, or in the Postman app.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; init; }

        /// <summary>
        /// Description can have versions associated with it, which should be put in this property.
        /// </summary>
        [JsonPropertyName("version")]
        public string? Version { get; init; }
    }

    /// <summary>
    /// Collection versioning information
    /// </summary>
    public record Version
    {
        /// <summary>
        /// Increment this number if you make changes to the collection that changes its behaviour. E.g: Removing or adding new test scripts. (partly or completely).
        /// </summary>
        [JsonPropertyName("major")]
        public long Major { get; init; }

        /// <summary>
        /// You should increment this number if you make changes that will not break anything that uses the collection. E.g: removing a folder.
        /// </summary>
        [JsonPropertyName("minor")]
        public long Minor { get; init; }

        /// <summary>
        /// Ideally, minor changes to a collection should result in the increment of this number
        /// </summary>
        [JsonPropertyName("patch")]
        public long Patch { get; init; }

        /// <summary>
        /// A human friendly identifier to make sense of the version numbers. E.g: 'beta-3'
        /// </summary>
        [JsonPropertyName("identifier")]
        public string? Identifier { get; init; }

        /// <summary>
        /// Additional information about the version. E.g: 'pre-release'
        /// </summary>
        [JsonPropertyName("meta")]
        public string? Meta { get; init; }
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
        public VariableType? Type { get; init; }

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

    [JsonConverter(typeof(JsonStringEnumConverter<VariableType>))]
    public enum VariableType
    {
        @string,
        boolean,
        any,
        number
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
        public AuthType? Type { get; init; }

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

    [JsonConverter(typeof(JsonStringEnumConverter<AuthType>))]
    public enum AuthType
    {
        apikey,
        awsv4,
        basic,
        bearer,
        digest,
        edgegrid,
        hawk,
        noauth,
        oauth1,
        oauth2,
        ntlm
    }

    public record NoAuth
    {
        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; init; }
    }

}