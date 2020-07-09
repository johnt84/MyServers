using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyServersWebApp.Model
{
    public class ServerInfo
    {
        public string ServiceID { get; set; }
		public string ServiceType { get; set; }
		public string PrimaryIP { get; set; }
		public string Location { get; set; }
		public string YourReference { get; set; }
		public string Status { get; set; }
		public bool Suspended { get; set; }
	}
}