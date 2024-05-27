namespace Hmb.Biriba.Models;

public class ParametricRequest
{
    public string? Method { get; set; }
    //public HttpMethod? Method { get; }
    
    public string? Uri { get; set; }
    //public Uri? Uri { get; set; }

    public string? Version { get; set; }
    //public Version? Version { get; set; }

    public IDictionary<string,string> Headers { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    //public HttpRequestHeaders? Headers { get; set; }

    public ParametricContent? Content { get; set; }
    //public HttpContent? Content { get; set; }




}
