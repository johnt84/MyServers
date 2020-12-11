using System;

namespace MyServersWebApp.Model.Payment
{
    public class MskResponse
    {
        public DateTime expiry { get; set; }
        public string merchantSessionKey { get; set; }
    }
}
