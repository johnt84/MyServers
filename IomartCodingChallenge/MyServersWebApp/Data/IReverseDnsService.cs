using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;

namespace MyServersWebApp.Data
{
    interface IReverseDnsService
    {
        List<ReverseDnsEntry> GetReverseDnsEntries();
    }
}
