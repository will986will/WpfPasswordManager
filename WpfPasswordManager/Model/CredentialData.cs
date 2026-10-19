using System;
using System.Collections.Generic;
using System.Text;

namespace WpfPasswordManager.Model
{
    public class CredentialData
    {
        public long CredentialId { get; set; }
        public string Title { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string WebsiteUrl { get; set; } = "";
        public string Notes { get; set; } = "";
    }
}
