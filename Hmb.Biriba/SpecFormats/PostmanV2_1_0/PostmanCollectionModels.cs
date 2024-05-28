using System.Text.Json.Serialization;
using System.Text.Json;

namespace Hmb.Biriba.SpecFormats.PostmanV2_1_0
{

    /// <summary>
    /// Represents an attribute for any authorization method provided by Postman. For example `username` and `password` are set as auth attributes for Basic Authentication method.
    /// </summary>
    public partial class AuthAttribute
    {
        [System.Text.Json.Serialization.JsonPropertyName("key")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Key { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public object? Value { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string? Type { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; set; }

    }

    /// <summary>
    /// Represents authentication helpers provided by Postman
    /// </summary>
    public partial class Auth
    {
        [System.Text.Json.Serialization.JsonPropertyName("type")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(JsonStringEnumConverter<AuthType>))]
        public AuthType Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("noauth")]
        public object? Noauth { get; set; }

        /// <summary>
        /// The attributes for API Key Authentication.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("apikey")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Apikey { get; set; }

        /// <summary>
        /// The attributes for [AWS Auth](http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html).
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("awsv4")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Awsv4 { get; set; }

        /// <summary>
        /// The attributes for [Basic Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication).
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("basic")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Basic { get; set; }

        /// <summary>
        /// The helper attributes for [Bearer Token Authentication](https://tools.ietf.org/html/rfc6750)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("bearer")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Bearer { get; set; }

        /// <summary>
        /// The attributes for [Digest Authentication](https://en.wikipedia.org/wiki/Digest_access_authentication).
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("digest")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Digest { get; set; }

        /// <summary>
        /// The attributes for [Akamai EdgeGrid Authentication](https://developer.akamai.com/legacy/introduction/Client_Auth.html).
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("edgegrid")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Edgegrid { get; set; }

        /// <summary>
        /// The attributes for [Hawk Authentication](https://github.com/hueniverse/hawk)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("hawk")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Hawk { get; set; }

        /// <summary>
        /// The attributes for [NTLM Authentication](https://msdn.microsoft.com/en-us/library/cc237488.aspx)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("ntlm")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Ntlm { get; set; }

        /// <summary>
        /// The attributes for [OAuth2](https://oauth.net/1/)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("oauth1")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Oauth1 { get; set; }

        /// <summary>
        /// Helper attributes for [OAuth2](https://oauth.net/2/)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("oauth2")]
        public System.Collections.Generic.ICollection<AuthAttribute>? Oauth2 { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// A representation of a list of ssl certificates
    /// </summary>
    public partial class CertificateList : System.Collections.ObjectModel.Collection<Certificate>
    {

    }

    /// <summary>
    /// A representation of an ssl certificate
    /// </summary>
    public partial class Certificate
    {
        /// <summary>
        /// A name for the certificate for user reference
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// A list of Url match pattern strings, to identify Urls this certificate can be used for.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("matches")]
        public System.Collections.Generic.ICollection<string>? Matches { get; set; }

        /// <summary>
        /// An object containing path to file containing private key, on the file system
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("key")]
        public Key? Key { get; set; }

        /// <summary>
        /// An object containing path to file certificate, on the file system
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("cert")]
        public Cert? Cert { get; set; }

        /// <summary>
        /// The passphrase for the certificate
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("passphrase")]
        public string? Passphrase { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// A representation of a list of cookies
    /// </summary>
    public partial class CookieList : System.Collections.ObjectModel.Collection<Cookie>
    {

    }

    /// <summary>
    /// A Cookie, that follows the [Google Chrome format](https://developer.chrome.com/extensions/cookies)
    /// </summary>
    public partial class Cookie
    {
        /// <summary>
        /// The domain for which this cookie is valid.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("domain")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Domain { get; set; }

        /// <summary>
        /// When the cookie expires.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("expires")]
        public string? Expires { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("maxAge")]
        public string? MaxAge { get; set; }

        /// <summary>
        /// True if the cookie is a host-only cookie. (i.e. a request's URL domain must exactly match the domain of the cookie).
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("hostOnly")]
        public bool? HostOnly { get; set; }

        /// <summary>
        /// Indicates if this cookie is HTTP Only. (if True, the cookie is inaccessible to client-side scripts)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("httpOnly")]
        public bool? HttpOnly { get; set; }

        /// <summary>
        /// This is the name of the Cookie.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The path associated with the Cookie.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("path")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Path { get; set; }

        /// <summary>
        /// Indicates if the 'secure' flag is set on the Cookie, meaning that it is transmitted over secure connections only. (typically HTTPS)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("secure")]
        public bool? Secure { get; set; }

        /// <summary>
        /// True if the cookie is a session cookie.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("session")]
        public bool? Session { get; set; }

        /// <summary>
        /// The value of the Cookie.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// Custom attributes for a cookie go here, such as the [Priority Field](https://code.google.com/p/chromium/issues/detail?id=232693)
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("extensions")]
        public System.Collections.Generic.ICollection<object>? Extensions { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// A Description can be a raw text, or be an object, which holds the description along with its format.
    /// </summary>
    public partial class Description
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class Description2
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// Postman allows you to configure scripts to run when specific events occur. These scripts are stored here, and can be referenced in the collection by their ID.
    /// </summary>
    public partial class EventList : System.Collections.ObjectModel.Collection<Event>
    {

    }

    /// <summary>
    /// Defines a script associated with an associated event name
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// A unique identifier for the enclosing event.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Can be set to `test` or `prerequest` for test scripts or pre-request scripts respectively.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("listen")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Listen { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("script")]
        public Script? Script { get; set; }

        /// <summary>
        /// Indicates whether the event is disabled. If absent, the event is assumed to be enabled.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("disabled")]
        public bool? Disabled { get; set; } = false;



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// A representation for a list of headers
    /// </summary>
    public partial class HeaderList : System.Collections.ObjectModel.Collection<Header>
    {

    }

    /// <summary>
    /// Represents a single HTTP Header
    /// </summary>
    public partial class Header
    {
        /// <summary>
        /// This holds the LHS of the HTTP Header, e.g ``Content-Type`` or ``X-Custom-Header``
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("key")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Key { get; set; }

        /// <summary>
        /// The value (or the RHS) of the Header is stored in this field.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("value")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Value { get; set; }

        /// <summary>
        /// If set to true, the current header will not be sent with requests.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("disabled")]
        public bool? Disabled { get; set; } = false;

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// Detailed description of the info block
    /// </summary>
    [JsonDerivedType(typeof(Info1))]
    [JsonDerivedType(typeof(Info2))]
    [JsonDerivedType(typeof(Info3))]
    [JsonDerivedType(typeof(Info4))]
    public partial class Info
    {
        /// <summary>
        /// A collection's friendly name is defined by this field. You would want to set this field to a value that would allow you to easily identify this collection among a bunch of other collections, as such outlining its usage or content.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        /// <summary>
        /// Every collection is identified by the unique value of this field. The value of this field is usually easiest to generate using a UID generator function. If you already have a collection, it is recommended that you maintain the same id since changing the id usually implies that is a different collection than it was originally.
        /// <br/> *Note: This field exists for compatibility reasons with Collection Format V1.*
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("_postman_id")]
        public string? _postman_id { get; set; }

        /// <summary>
        /// This should ideally hold a link to the Postman schema that is used to validate this collection. E.g: https://schema.getpostman.com/collection/v1
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("schema")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Schema { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class Info1 : Info
    {
        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("version")]
        public Version? Version { get; set; }
    }

    public partial class Info2 : Info
    {
        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("version")]
        public Version? Version { get; set; }
    }

    public partial class Info3 : Info
    {
        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("version")]
        public string? Version { get; set; }
    }

    public partial class Info4 : Info
    {
        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("version")]
        public string? Version { get; set; }
    }

    /// <summary>
    /// One of the primary goals of Postman is to organize the development of APIs. To this end, it is necessary to be able to group requests together. This can be achived using 'Folders'. A folder just is an ordered set of requests.
    /// </summary>
    public partial class ItemGroup
    {
        /// <summary>
        /// A folder's friendly name is defined by this field. You would want to set this field to a value that would allow you to easily identify this folder.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("variable")]
        public VariableList? Variable { get; set; }

        /// <summary>
        /// Items are entities which contain an actual HTTP request, and sample responses attached to it. Folders may contain many items.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("item")]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<item> Item { get; set; } = new System.Collections.ObjectModel.Collection<item>();

        [System.Text.Json.Serialization.JsonPropertyName("event")]
        public EventList? Event { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public Auth? Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("protocolProfileBehavior")]
        public ProtocolProfileBehavior? ProtocolProfileBehavior { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// Items are entities which contain an actual HTTP request, and sample responses attached to it.
    /// </summary>
    public partial class Item
    {
        /// <summary>
        /// A unique ID that is used to identify collections internally
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// A human readable identifier for the current item.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("variable")]
        public VariableList? Variable { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("event")]
        public EventList? Event { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("request")]
        [System.ComponentModel.DataAnnotations.Required]
        public Request2 Request { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("response")]
        public System.Collections.Generic.ICollection<Response>? Response { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("protocolProfileBehavior")]
        public ProtocolProfileBehavior? ProtocolProfileBehavior { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// Set of configurations used to alter the usual behavior of sending the request
    /// </summary>
    public partial class ProtocolProfileBehavior
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// Using the Proxy, you can configure your custom proxy into the postman for particular url match
    /// </summary>
    public partial class ProxyConfig
    {
        /// <summary>
        /// The Url match for which the proxy config is defined
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("match")]
        public string? Match { get; set; } = "http+https://*/*";

        /// <summary>
        /// The proxy server host
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("host")]
        public string? Host { get; set; }

        /// <summary>
        /// The proxy server port
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("port")]
        [System.ComponentModel.DataAnnotations.Range(0, int.MaxValue)]
        public int? Port { get; set; } = 8080;

        /// <summary>
        /// The tunneling details for the proxy config
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("tunnel")]
        public bool? Tunnel { get; set; } = false;

        /// <summary>
        /// When set to true, ignores this proxy configuration entity
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("disabled")]
        public bool? Disabled { get; set; } = false;



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// A request represents an HTTP request. If a string, the string is assumed to be the request URL and the method is assumed to be 'GET'.
    /// </summary>
    public partial class Request
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }
    public partial class Request2
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// A response represents an HTTP response.
    /// </summary>
    public partial class Response
    {
        /// <summary>
        /// A unique, user defined identifier that can  be used to refer to this response from requests.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("originalRequest")]
        public Request2? OriginalRequest { get; set; }

        /// <summary>
        /// The time taken by the request to complete. If a number, the unit is milliseconds. If the response is manually created, this can be set to `null`.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("responseTime")]
        public double? ResponseTime { get; set; }

        /// <summary>
        /// Set of timing information related to request and response in milliseconds
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("timings")]
        public object? Timings { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("header")]
        public System.Collections.Generic.ICollection<Header>? Header { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cookie")]
        public System.Collections.Generic.ICollection<Cookie>? Cookie { get; set; }

        /// <summary>
        /// The raw text of the response.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("body")]
        public string? Body { get; set; }

        /// <summary>
        /// The response status, e.g: '200 OK'
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The numerical response code, example: 200, 201, 404, etc.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("code")]
        public int? Code { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// A script is a snippet of Javascript code that can be used to to perform setup or teardown operations on a particular response.
    /// </summary>
    public partial class Script
    {
        /// <summary>
        /// A unique, user defined identifier that can  be used to refer to this script from requests.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Type of the script. E.g: 'text/javascript'
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string? Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("exec")]
        public System.Collections.Generic.ICollection<string>? Exec { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("src")]
        public Url2? Src { get; set; }

        /// <summary>
        /// Script name
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// If object, contains the complete broken-down URL for this request. If string, contains the literal request URL.
    /// </summary>
    public partial class Url
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class Url2
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// Collection variables allow you to define a set of variables, that are a *part of the collection*, as opposed to environments, which are separate entities.
    /// <br/>*Note: Collection variables must not contain any sensitive information.*
    /// </summary>
    public partial class VariableList : System.Collections.ObjectModel.Collection<Variable>
    {

    }

    /// <summary>
    /// Using variables in your Postman requests eliminates the need to duplicate requests, which can save a lot of time. Variables can be defined, and referenced to from any part of a request.
    /// </summary>
    public partial class Variable
    {
        /// <summary>
        /// A variable ID is a unique user-defined value that identifies the variable within a collection. In traditional terms, this would be a variable name.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// A variable key is a human friendly value that identifies the variable within a collection. In traditional terms, this would be a variable name.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("key")]
        public string? Key { get; set; }

        /// <summary>
        /// The value that a variable holds in this collection. Ultimately, the variables will be replaced by this value, when say running a set of requests from a collection
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public object? Value { get; set; }

        /// <summary>
        /// A variable may have multiple types. This field specifies the type of the variable.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter<VariableType>))]
        public VariableType? Type { get; set; }

        /// <summary>
        /// Variable name
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }

        /// <summary>
        /// When set to true, indicates that this variable has been set by Postman
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("system")]
        public bool? System { get; set; } = false;

        [System.Text.Json.Serialization.JsonPropertyName("disabled")]
        public bool? Disabled { get; set; } = false;



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// Postman allows you to version your collections as they grow, and this field holds the version number. While optional, it is recommended that you use this field to its fullest extent!
    /// </summary>
    public partial class Version
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class PostmanCollectionDocument
    {
        [System.Text.Json.Serialization.JsonPropertyName("info")]
        [System.ComponentModel.DataAnnotations.Required]
        public Info Info { get; set; } = new Info();

        /// <summary>
        /// Items are the basic unit for a Postman collection. You can think of them as corresponding to a single API endpoint. Each Item has one request and may have multiple API responses associated with it.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("item")]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<Item> Item { get; set; } = new System.Collections.ObjectModel.Collection<Item>();

        [System.Text.Json.Serialization.JsonPropertyName("event")]
        public EventList? Event { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("variable")]
        public VariableList? Variable { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public Auth? Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("protocolProfileBehavior")]
        public ProtocolProfileBehavior? ProtocolProfileBehavior { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public enum AuthType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"apikey")]
        Apikey = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"awsv4")]
        Awsv4 = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"basic")]
        Basic = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"bearer")]
        Bearer = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"digest")]
        Digest = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"edgegrid")]
        Edgegrid = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"hawk")]
        Hawk = 6,


        [System.Runtime.Serialization.EnumMember(Value = @"noauth")]
        Noauth = 7,


        [System.Runtime.Serialization.EnumMember(Value = @"oauth1")]
        Oauth1 = 8,


        [System.Runtime.Serialization.EnumMember(Value = @"oauth2")]
        Oauth2 = 9,


        [System.Runtime.Serialization.EnumMember(Value = @"ntlm")]
        Ntlm = 10,


    }

    public partial class Key
    {
        /// <summary>
        /// The path to file containing key for certificate, on the file system
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("src")]
        public object? Src { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class Cert
    {
        /// <summary>
        /// The path to file containing key for certificate, on the file system
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("src")]
        public object? Src { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class item
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class Method
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    /// <summary>
    /// This field contains the data usually contained in the request body.
    /// </summary>
    public partial class Body
    {
        /// <summary>
        /// Postman stores the type of data associated with this request in this field.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("mode")]
        public BodyMode? Mode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("raw")]
        public string? Raw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("graphql")]
        public object? Graphql { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("urlencoded")]
        public System.Collections.Generic.ICollection<Urlencoded>? Urlencoded { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("formdata")]
        public System.Collections.Generic.ICollection<Formdata>? Formdata { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("file")]
        public File? File { get; set; }

        /// <summary>
        /// Additional configurations and options set for various body modes.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("options")]
        public object? Options { get; set; }

        /// <summary>
        /// When set to true, prevents request body from being sent.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("disabled")]
        public bool? Disabled { get; set; } = false;



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class Query
    {
        [System.Text.Json.Serialization.JsonPropertyName("key")]
        public string? Key { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// If set to true, the current query parameter will not be sent with the request.
        /// </summary>
        [System.Text.Json.Serialization.JsonPropertyName("disabled")]
        public bool? Disabled { get; set; } = false;

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public enum VariableType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"string")]
        String = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"boolean")]
        Boolean = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"any")]
        Any = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"number")]
        Number = 3,


    }

    public enum BodyMode
    {

        [System.Runtime.Serialization.EnumMember(Value = @"raw")]
        Raw = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"urlencoded")]
        Urlencoded = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"formdata")]
        Formdata = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"file")]
        File = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"graphql")]
        Graphql = 4,


    }

    public partial class Urlencoded
    {
        [System.Text.Json.Serialization.JsonPropertyName("key")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Key { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public string? Value { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("disabled")]
        public bool? Disabled { get; set; } = false;

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public Description? Description { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class Formdata
    {


        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }

    public partial class File
    {
        [System.Text.Json.Serialization.JsonPropertyName("src")]
        public string? Src { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("content")]
        public string? Content { get; set; }



        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }

    }
}