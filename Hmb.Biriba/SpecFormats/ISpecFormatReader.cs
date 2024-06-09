using Hmb.Biriba.Scanner;

namespace Hmb.Biriba.SpecFormats;

public interface ISpecFormatReader
{
    SpecReaderFormat Format { get; }

    IAsyncEnumerable<ParametricRequest> GetParametricRequestsAsync(Stream fileStream);
}
