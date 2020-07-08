using MyServersWebApp.MyServersApiSimulatorService;
using System.Collections.Generic;
using System.Linq;

namespace MyServersWebApp.Data
{
    public class ReverseDnsService : IReverseDnsService
    {
        public List<ReverseDnsEntry> GetReverseDnsEntries()
        {
            return GlobalSettings.apiClient.GetReverseDnsEntries(GlobalSettings.authInfo).ToList();
        }
    }
}