namespace ConfigurationTool.Common.ConfigurationFactory
{
    public interface IConfigurationFactory
    {
        T GetConfig<T>() where T : class;
    }
}
