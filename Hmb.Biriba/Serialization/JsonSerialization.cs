namespace Hmb.Biriba.Serialization;

public class JsonSerialization
{
    public ValueTask<T?> DeserializeAsync<T>(Stream jsonStream, CancellationToken cancellationToken = default) 
        => System.Text.Json.JsonSerializer.DeserializeAsync<T?>(jsonStream, cancellationToken: cancellationToken);
}
