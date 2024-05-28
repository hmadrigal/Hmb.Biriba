namespace Hmb.Biriba.SpecFormats.HttpArchiveV1_2
{

#nullable disable

    /// <summary>
    /// HTTP Archive document.
    /// </summary>
    public record HarDocument
    {
        /// <summary>
        /// Represents the root of exported data.
        /// </summary>
        public Log log { get; init; }
    }

    /// <summary>
    /// This class represents the root of exported data.
    /// </summary>
    public record Log
    {
        /// <summary>
        /// Version number of the format. If empty, string "1.1" is assumed by default.
        /// </summary>
        public string version { get; init; } = "1.1";
        /// <summary>
        /// Name and version info of the log creator application.
        /// </summary>
        public Creator creator { get; init; }
        /// <summary>
        /// Name and version info of used browser.
        /// </summary>
        public Browser? browser { get; init; }
        /// <summary>
        /// List of all exported (tracked) pages. Leave out this field if the application does not support grouping by pages.
        /// </summary>
        public Page[]? pages { get; init; }
        /// <summary>
        /// List of all exported (tracked) requests.
        /// </summary>
        public Entry[] entries { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This class represents the browser information.
    /// </summary>
    public record Browser : NameVersion { }
    /// <summary>
    /// This class represents the creator application information.
    /// </summary>
    public record Creator : NameVersion { }

    /// <summary>
    /// This class represents an entity with a name and a version.
    /// </summary>
    public abstract record NameVersion
    {
        /// <summary>
        /// Name of the application/browser used to export the log.
        /// </summary>
        public string name { get; init; }
        /// <summary>
        /// Version of the application/browser used to export the log.
        /// </summary>
        public string version { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }

    }

    /// <summary>
    /// This class represents an entity with a name and a value.
    /// </summary>
    public abstract record NameValue
    {
        /// <summary>
        /// Name of the application/browser used to export the log.
        /// </summary>
        public string name { get; init; }
        /// <summary>
        /// Version of the application/browser used to export the log.
        /// </summary>
        public string value { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }

    }

    /// <summary>
    /// This class represents list of exported pages.
    /// </summary>
    public record Page
    {
        /// <summary>
        /// Date and time stamp for the beginning of the page load (ISO 8601 - YYYY-MM-DDThh:mm:ss.sTZD, e.g. 2009-07-24T19:20:30.45+01:00).
        /// </summary>
        public string startedDateTime { get; init; }
        /// <summary>
        /// Unique identifier of a page within the <log>. Entries use it to refer the parent page.
        /// </summary>
        public string id { get; init; }
        /// <summary>
        /// Page title.
        /// </summary>
        public string title { get; init; }
        /// <summary>
        /// Detailed timing info about page load.
        /// </summary>
        public PageTimings pageTimings { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This object describes timings for various events (states) fired during the page load. All times are specified in milliseconds. If a time info is not available appropriate field is set to -1.
    /// </summary>
    public record PageTimings
    {
        /// <summary>
        /// Content of the page loaded. Number of milliseconds since page load started (page.startedDateTime). Use -1 if the timing does not apply to the current request.
        /// </summary>
        /// <remarks>
        /// Depeding on the browser, onContentLoad property represents DOMContentLoad event or document.readyState == interactive
        /// </remarks>
        public double? onContentLoad { get; init; } = -1;
        /// <summary>
        /// Page is loaded (onLoad event fired). Number of milliseconds since page load started (page.startedDateTime). Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double? onLoad { get; init; } = -1;
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This class represents an array with all exported HTTP requests. Sorting entries by startedDateTime (starting from the oldest) is preferred way how to export data since it can make importing faster. However the reader application should always make sure the array is sorted (if required for the import).
    /// </summary>
    public record Entry
    {
        /// <summary>
        /// Reference to the parent page. Leave out this field if the application does not support grouping by pages.
        /// </summary>
        public string? pageref { get; init; }
        /// <summary>
        /// Date and time stamp of the request start (ISO 8601 - YYYY-MM-DDThh:mm:ss.sTZD).
        /// </summary>
        public string startedDateTime { get; init; }
        /// <summary>
        /// Total elapsed time of the request in milliseconds. This is the sum of all timings available in the timings object (i.e. not including -1 values) .
        /// </summary>
        public double? time { get; init; }
        /// <summary>
        /// Detailed info about the request.
        /// </summary>
        public Request request { get; init; }
        /// <summary>
        /// Detailed info about the response.
        /// </summary>
        public Response response { get; init; }
        /// <summary>
        /// Info about cache usage.
        /// </summary>
        public Cache cache { get; init; }
        /// <summary>
        /// Detailed timing info about request/response round trip.
        /// </summary>
        public Timings timings { get; init; }
        /// <summary>
        /// IP address of the server that was connected (result of DNS resolution).
        /// </summary>
        public string? serverIPAddress { get; init; }
        /// <summary>
        /// Unique ID of the parent TCP/IP
        /// </summary>
        public string? connection { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This object contains detailed info about performed request.
    /// </summary>
    public record Request
    {
        /// <summary>
        /// Request method (GET, POST, ...).
        /// </summary>
        public string method { get; init; }
        /// <summary>
        /// Absolute URL of the request (fragments are not included).
        /// </summary>
        public string url { get; init; }
        /// <summary>
        /// Request HTTP Version.
        /// </summary>
        public string httpVersion { get; init; }
        /// <summary>
        /// List of cookie objects.
        /// </summary>
        public Cookie[] cookies { get; init; }
        /// <summary>
        /// List of header objects.
        /// </summary>
        public Header[] headers { get; init; }
        /// <summary>
        /// List of query parameter objects.
        /// </summary>
        public QueryString[] queryString { get; init; }
        /// <summary>
        /// Posted data info.
        /// </summary>
        public PostData? postData { get; init; }
        /// <summary>
        /// Total number of bytes from the start of the HTTP request message until (and including) the double CRLF before the body. Set to -1 if the info is not available.
        /// </summary>
        public long headersSize { get; init; } = -1;
        /// <summary>
        /// Size of the request body (POST data payload) in bytes. Set to -1 if the info is not available.
        /// </summary>
        public long bodySize { get; init; } = -1;
    }

    /// <summary>
    /// This object contains list of all headers (used in <request> and <response> objects).
    /// </summary>
    public record Header : NameValue
    { }

    /// <summary>
    /// This object contains list of all parameters & values parsed from a query string, if any (embedded in <request> object).
    /// </summary>
    public record QueryString : NameValue
    { }

    /// <summary>
    /// This object describes posted data, if any (embedded in <request> object).
    /// </summary>
    public record PostData
    {
        /// <summary>
        /// Mime type of posted data.
        /// </summary>
        public string mimeType { get; init; }
        /// <summary>
        /// List of posted parameters (in case of URL encoded parameters).
        /// </summary>
        public Param[] @params { get; init; }
        /// <summary>
        /// Plain text posted data
        /// </summary>
        /// <remarks>Note that <see cref="text"/> and <see cref="@params"/> fields are mutually exclusive.</remarks>
        public string text { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// List of posted parameters, if any (embedded in <postData> object).
    /// </summary>
    public record Param
    {
        /// <summary>
        /// name of a posted parameter.
        /// </summary>
        public string name { get; init; }
        /// <summary>
        /// value of a posted parameter or content of a posted file.
        /// </summary>
        public string? value { get; init; }
        /// <summary>
        /// name of a posted file.
        /// </summary>
        public string? fileName { get; init; }
        /// <summary>
        /// content type of a posted file.
        /// </summary>
        public string? contentType { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This object contains list of all cookies (used in <request> and <response> objects).
    /// </summary>
    public record Cookie
    {
        /// <summary>
        /// The name of the cookie.
        /// </summary>
        public string name { get; init; }
        /// <summary>
        /// The cookie value.
        /// </summary>
        public string value { get; init; }
        /// <summary>
        /// The path pertaining to the cookie.
        /// </summary>
        public string? path { get; init; }
        /// <summary>
        /// The host of the cookie.
        /// </summary>
        public string? domain { get; init; }
        /// <summary>
        /// Cookie expiration time. (ISO 8601 - YYYY-MM-DDThh:mm:ss.sTZD, e.g. 2009-07-24T19:20:30.123+02:00).
        /// </summary>
        public string? expires { get; init; }
        /// <summary>
        /// Set to true if the cookie is HTTP only, false otherwise.
        /// </summary>
        public bool? httpOnly { get; init; }
        /// <summary>
        /// True if the cookie was transmitted over ssl, false otherwise.
        /// </summary>
        public bool? secure { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This object contains detailed info about the response.
    /// </summary>
    public record Response
    {
        /// <summary>
        /// Response status.
        /// </summary>
        public int status { get; init; }
        /// <summary>
        /// Response status description.
        /// </summary>
        public string statusText { get; init; }
        /// <summary>
        /// Response HTTP Version.
        /// </summary>
        public string httpVersion { get; init; }
        /// <summary>
        /// List of cookie objects.
        /// </summary>
        public Cookie[] cookies { get; init; }
        /// <summary>
        /// List of header objects.
        /// </summary>
        public Header[] headers { get; init; }
        /// <summary>
        /// Details about the response body.
        /// </summary>
        public Content content { get; init; }
        /// <summary>
        /// Redirection target URL from the Location response header.
        /// </summary>
        public string redirectURL { get; init; }
        /// <summary>
        /// Total number of bytes from the start of the HTTP response message until (and including) the double CRLF before the body. Set to -1 if the info is not available.
        /// </summary>
        public long headersSize { get; init; } = -1;
        /// <summary>
        /// Size of the received response body in bytes. Set to zero in case of responses coming from the cache (304). Set to -1 if the info is not available.
        /// </summary>
        public long bodySize { get; init; } = -1;
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This object describes details about response content (embedded in <response> object).
    /// </summary>
    public record Content
    {
        /// <summary>
        /// Length of the returned content in bytes. Should be equal to response.bodySize if there is no compression and bigger when the content has been compressed.
        /// </summary>
        public long size { get; init; }
        /// <summary>
        /// Number of bytes saved. Leave out this field if the information is not available.
        /// </summary>
        public long? compression { get; init; }
        /// <summary>
        /// MIME type of the response text (value of the Content-Type response header). The charset attribute of the MIME type is included (if available).
        /// </summary>
        public string mimeType { get; init; }
        /// <summary>
        /// Response body sent from the server or loaded from the browser cache. This field is populated with textual content only. The text field is either HTTP decoded text or a encoded (e.g. "base64") representation of the response body. Leave out this field if the information is not available.
        /// </summary>
        public string? text { get; init; }
        /// <summary>
        /// Encoding used for response text field e.g "base64". Leave out this field if the text field is HTTP decoded (decompressed & unchunked), than trans-coded from its original character set into UTF-8.
        /// </summary>
        public string? encoding { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This objects contains info about a request coming from browser cache.
    /// </summary>
    public record Cache
    {
        /// <summary>
        /// State of a cache entry before the request. Leave out this field if the information is not available.
        /// </summary>
        public CacheState? beforeRequest { get; init; }
        /// <summary>
        /// State of a cache entry after the request. Leave out this field if the information is not available.
        /// </summary>
        public CacheState? afterRequest { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// State of a cache entry
    /// </summary>
    public abstract record class CacheState
    {
        /// <summary>
        /// Expiration time of the cache entry.
        /// </summary>
        public string? expires { get; init; }
        /// <summary>
        /// The last time the cache entry was opened.
        /// </summary>
        public string lastAccess { get; init; }
        /// <summary>
        /// Etag
        /// </summary>
        public string eTag { get; init; }
        /// <summary>
        /// The number of times the cache entry has been opened.
        /// </summary>
        public long hitCount { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

    /// <summary>
    /// This object describes various phases within request-response round trip. All times are specified in milliseconds.
    /// </summary>
    public record Timings
    {
        /// <summary>
        /// Time spent in a queue waiting for a network connection. Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double? blocked { get; init; }
        /// <summary>
        /// DNS resolution time. The time required to resolve a host name. Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double? dns { get; init; }
        /// <summary>
        /// Time required to create TCP connection. Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double? connect { get; init; }
        /// <summary>
        /// Time required to send HTTP request to the server.
        /// </summary>
        public double send { get; init; }
        /// <summary>
        /// Waiting for a response from the server.
        /// </summary>
        public double wait { get; init; }
        /// <summary>
        /// Time required to read entire response from the server (or cache).
        /// </summary>
        public double receive { get; init; }
        /// <summary>
        /// Time required for SSL/TLS negotiation. If this field is defined then the time is also included in the connect field (to ensure backward compatibility with HAR 1.1). Use -1 if the timing does not apply to the current request.
        /// </summary>
        public double ssl { get; init; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        public string? comment { get; init; }
    }

#nullable enable

}
