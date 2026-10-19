using System;
using System.Collections.Generic;
using System.Text;

namespace WpfPasswordManager.Model
{
    public class PasswordHistoryEntry
    {
        public long HistoryId { get; set; }

        public long CredentialId { get; set; }

        public DateTimeOffset ChangedAt { get; set; }

        // Will be decrypted only when history requested.
        public string Password { get; set; } = "";
    }
}
