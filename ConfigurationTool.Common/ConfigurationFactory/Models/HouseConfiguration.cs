namespace ConfigurationTool.Common.ConfigurationFactory.Models
{
    public record HouseConfiguration
    {
        public string? Location { get; set; }
        public int? Floor { get; set; }
        public bool? HasElevator { get; set; }
    }
}
