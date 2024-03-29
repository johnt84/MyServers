﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyServersWebApp.Services
{
    public class ServerDBService : IServerDBService
    {
        private IDbConnection Connection => GlobalSettings.MyServersDBConnection;

        public ServerDBService()
        {
        }

        public List<Model.ServerInfo> Get()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var serverList = connection
                                        .Query<Model.ServerInfo>(
                                            "procServersGet",
                                            commandType: CommandType.StoredProcedure)
                                        .ToList();


                return serverList;
            }
        }
    }
}