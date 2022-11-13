using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Settings
{
    public class DatabaseConfig
    {
        [JsonPropertyName("Connection")]
        public string Connection { get; set; }

        [JsonPropertyName("EnableMigration")]
        public bool EnableMigration { get; set; }
    }
}
