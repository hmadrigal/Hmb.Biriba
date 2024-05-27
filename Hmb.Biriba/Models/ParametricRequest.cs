using System.Collections.Specialized;

namespace Hmb.Biriba.Models;

public class ParametricRequest
{
    public string? Method { get; set; }

    public string? Uri { get; set; }

    public NameValueCollection QueryString { get; private set; } = new NameValueCollection();

    public string? Version { get; set; }

    public IDictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    public ParametricContent? Content { get; set; }

}
