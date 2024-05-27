namespace Hmb.Biriba.DocumentFormats.HttpArchive
{

#nullable disable

    public record HarDocument
    {
        public Log log { get; init; }
    }

    public record Log
    {
        public string version { get; init; }
        public Creator creator { get; init; }
        public Page[] pages { get; init; }
        public Entry[] entries { get; init; }
    }

    public record Creator
    {
        public string name { get; init; }
        public string version { get; init; }
    }

    public record Page
    {
        public string startedDateTime { get; init; }
        public string id { get; init; }
        public string title { get; init; }
        public PageTimings pageTimings { get; init; }
    }

    public record PageTimings
    {
        public int onContentLoad { get; init; }
        public int onLoad { get; init; }
    }

    public record Entry
    {
        public string startedDateTime { get; init; }
        public int time { get; init; }
        public Request request { get; init; }
        public Response response { get; init; }
        public Cache cache { get; init; }
        public Timings timings { get; init; }
        public string serverIPAddress { get; init; }
        public string connection { get; init; }
        public string pageref { get; init; }
    }

    public record Request
    {
        public string method { get; init; }
        public string url { get; init; }
        public string httpVersion { get; init; }
        public Header[] headers { get; init; }
        public QueryString[] queryString { get; init; }
        public PostData postData { get; init; }
        public Cookie[] cookies { get; init; }
        public Header[] headersSize { get; init; }
        public int bodySize { get; init; }
    }

    public record Header
    {
        public string name { get; init; }
        public string value { get; init; }
    }

    public record QueryString
    {
        public string name { get; init; }
        public string value { get; init; }
        public string comment { get; init; }

    }

    public record PostData
    {
        public string mimeType { get; init; }
        public string text { get; init; }
        public Param[] @params { get; init; }
        public string comment { get; init; }
    }

    public record Param
    {
        public string name { get; init; }
        public string value { get; init; }
        public string fileName { get; init; }
        public string contentType { get; init; }
        public string comment { get; init; }
    }

    public record Cookie
    {
        public string name { get; init; }
        public string value { get; init; }
        public string path { get; init; }
        public string domain { get; init; }
        public string expires { get; init; }
        public bool httpOnly { get; init; }
        public bool secure { get; init; }
    }

    public record Response
    {
        public int status { get; init; }
        public string statusText { get; init; }
        public string httpVersion { get; init; }
        public Header[] headers { get; init; }
        public Cookie[] cookies { get; init; }
        public Content content { get; init; }
        public string redirectURL { get; init; }
        public int headersSize { get; init; }
        public int bodySize { get; init; }
        public string comment { get; init; }
    }

    public record Content
    {
        public int size { get; init; }
        public int compression { get; init; }
        public string mimeType { get; init; }
        public string text { get; init; }
    }

    public record Cache
    {
        public string beforeRequest { get; init; }
        public string afterRequest { get; init; }
    }

    public record Timings
    {
        public int blocked { get; init; }
        public int dns { get; init; }
        public int connect { get; init; }
        public int send { get; init; }
        public int wait { get; init; }
        public int receive { get; init; }
        public int ssl { get; init; }
    }

#nullable enable

}
