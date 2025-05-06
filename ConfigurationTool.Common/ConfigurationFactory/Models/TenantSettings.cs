namespace ConfigurationTool.Common.ConfigurationFactory.Models
{
    public record TenantSettings
    {
        public string DefaultTenant { get; set; } = string.Empty;
        public List<Tenant> Tenants { get; set; } = new();
        public GlobalSettings GlobalSettings { get; set; } = new();
    }

    public record Tenant
    {
        public string Name { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public Features Features { get; set; } = new();
    }

    public record Features
    {
        public bool EnableLogging { get; set; }
        public int MaxUsers { get; set; }
        public List<string> AllowedRegions { get; set; } = new();
    }

    public record GlobalSettings
    {
        public string SupportEmail { get; set; } = string.Empty;
        public int ApiRateLimit { get; set; }
    }
}
