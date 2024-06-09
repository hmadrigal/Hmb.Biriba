using Hmb.Biriba.Scanner;
using Hmb.Biriba.SpecFormats;
using MediatR;

namespace Hmb.Biriba.Requests.Scanner;

public class RunRequest : IRequest<int>
{
    public string SpecificationFilePath { get; set; } = string.Empty;
    public SpecReaderFormat SpecificationFormat { get; set; }
}
public class RunScannerRequestHandler : IRequestHandler<RunRequest, int>
{
    private readonly Biriba.Scanner.VulnerabilityScanner _scanner;

    public RunScannerRequestHandler(Biriba.Scanner.VulnerabilityScanner vulnerabilityScanner)
    {
        _scanner = vulnerabilityScanner;
    }
    public async Task<int> Handle(RunRequest runRequest, CancellationToken cancellationToken)
    {

        await _scanner.RunVulnerabilityScan(runRequest.SpecificationFormat, runRequest.SpecificationFilePath);

        return await Task.FromResult(0);
    }
}