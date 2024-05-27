namespace Hmb.Biriba.Models;

public class ParametricContent
{
    public string? MediaType { get; set; }
    public string? Content { get; set; }
    //public HttpContent? Content { get; set; }
    public IDictionary<string,string> Headers { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
}
