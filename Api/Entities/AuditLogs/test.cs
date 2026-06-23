using System.Text.Json.Serialization;

namespace Api.Entities.AuditLogs
{

    public sealed record Root
    {
        [JsonPropertyName("ssa")]
        public TestParent ssa { get; set; }
        public sealed record TestParent
        {
            [JsonPropertyName("ssa")]
            public string? ssa { get; set; }
        }
    }
}


