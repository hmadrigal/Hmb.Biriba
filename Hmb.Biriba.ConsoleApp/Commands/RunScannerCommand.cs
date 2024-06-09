namespace Hmb.Biriba.ConsoleApp.Commands
{
    using System;
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.Threading.Tasks;
    using Hmb.Biriba.Requests.Scanner;
    using Hmb.Biriba.SpecFormats;
    using MediatR;

    public class RunScannerCommand : Command
    {
        public Option<string> SpecOption { get; private set; }
        public Option<SpecReaderFormat> FormatOption { get; private set; }

        public RunScannerCommand()
            : base(name: "run", "Run the scanner")
        {
            this.AddOption(SpecOption = new Option<string>(
                ["--spec", "-s"], "The specification document either local file path or remote HTTP(S) uri.")
            { IsRequired = true });
            this.AddOption(FormatOption = new Option<SpecReaderFormat>(
                ["--format", "-f"], "The specification document format.")
            { IsRequired = true });
        }

        public new class Handler : ICommandHandler
        {
            private readonly IMediator _mediator;

            public string Title { get; set; }

            public Handler(IMediator mediator) =>
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            public async Task<int> InvokeAsync(InvocationContext context)
            {
                RunRequest runRequest = new RunRequest
                { };

                if (context.BindingContext.ParseResult.CommandResult.Command is RunScannerCommand runScannerCommand)
                {
                    runRequest.SpecificationFilePath = context.BindingContext.ParseResult.GetValueForOption<string>(runScannerCommand.SpecOption)!;
                    runRequest.SpecificationFormat = context.BindingContext.ParseResult.GetValueForOption<SpecReaderFormat>(runScannerCommand.FormatOption)!;
                }

                await _mediator.Send(runRequest);

                return 0;
            }

            public int Invoke(InvocationContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}