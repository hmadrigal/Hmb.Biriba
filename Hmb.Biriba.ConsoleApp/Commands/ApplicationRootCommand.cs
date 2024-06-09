using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hmb.Biriba.ConsoleApp.Commands;

public class ApplicationRootCommand : RootCommand
{
    public Option<bool> SilentOption { get; set; }

    public ApplicationRootCommand()
    {
        AddGlobalOption(SilentOption = new Option<bool>("--silent", "Disables diagnostics output"));
    }
}
