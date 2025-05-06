namespace ConfigurationTool.Common.ConfigurationFactory.Models
{
    public record ConnectionStrings
    {
        public string DefaultConnectionString { get; set; } = string.Empty;
        public string LoggingDatabase { get; set; } = string.Empty;
    }
}
