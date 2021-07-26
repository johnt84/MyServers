using System.Collections.Generic;

namespace MyServersWebApp.Services
{
    public interface IServerDBService
    {
        List<Model.ServerInfo> Get();
    }
}
