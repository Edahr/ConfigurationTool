namespace ConfigurationTool.Configuration
{
    using ConfigurationTool.Common.ConfigurationFactory.Models;
    public class ConfigurationRegistrar
    {
        /// <summary>
        /// Registers configuration sections from multiple JSON files.
        /// </summary>
        public static void RegisterConfigurations(WebApplicationBuilder builder)
        {
            LoadConfigurationFromAppSettings(builder);

            LoadConfigurationFromConfigurationFolder(builder);
        }

        private static void LoadConfigurationFromConfigurationFolder(WebApplicationBuilder builder)
        {
            // Register configurations for extension files
            RegisterAndBindConfigurationSection<ConnectionStrings>(builder, "ConnectionStrings.json", "ConnectionStrings", "ConnectionStrings");
            RegisterAndBindConfigurationSection<TenantSettings>(builder, "TenantSettings.json", "TenantSettings", "Tenants");
        }

        private static void LoadConfigurationFromAppSettings(WebApplicationBuilder builder)
        {
            // Load configuration from appsettings
            builder.Services.Configure<HouseConfiguration>(builder.Configuration.GetSection("HouseConfiguration"));
        }

        /// <summary>
        /// A generic method to register and bind a configuration section from a JSON file
        /// </summary>
        /// <typeparam name="T">The type of the configuration class.</typeparam>
        /// <param name="builder">The WebApplicationBuilder instance.</param>
        /// <param name="fileName">The name of the configuration file.</param>
        /// <param name="sectionName">The section name within the JSON file.</param>
        private static void RegisterAndBindConfigurationSection<T>(
            WebApplicationBuilder builder,
            string fileName,
            string sectionName,
            string filePath = "") where T : class
        {
            try
            {
                var configPath = builder.Configuration["ConfigurationPath"];

                // If still not found, throw an error (fail-safe mechanism)
                if (string.IsNullOrEmpty(configPath))
                {
                    throw new InvalidOperationException("ConfigurationPath is not set");
                }

                // Build the full path to the configuration file
                var fullPath = Path.Combine(configPath, filePath ?? string.Empty, fileName);

                // Add the JSON file to the configuration (it will automatically reload when the file changes)
                builder.Configuration.AddJsonFile(fullPath, optional: false, reloadOnChange: true);

                //Bind the configuration section to a C# class so that it can be used through IOptions 
                builder.Services.Configure<T>(
                    builder.Configuration.GetSection(sectionName));
            }
            catch (Exception ex)
            {
                // Log the exception for troubleshooting
                Console.WriteLine($"Error registering configuration section '{sectionName}' from file '{fileName}': {ex.Message}");
                throw new InvalidOperationException($"Failed to load configuration from file: {fileName}", ex);
            }
        }
    }
}
