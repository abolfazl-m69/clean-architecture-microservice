namespace HumanResource.Framework.Common
{
    public class SiteSettings
    {
        public string FileServiceUrl { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public RabbitSettings RabbitSettings { get; set; }
        public string OrderServiceUrl { get; set; }
        public RedisSettings RedisSettings { get; set; }
    }

    public class EventSourceConfig
    {
        public string PublishEventConnectionString { get; set; }
        public string ConsumerEventConnectionString { get; set; }
    }
    public class RabbitSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public int RetryCount { get; set; }
        public string QueueName { get; set; }
        public string Scheduler { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Encryptkey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
        public string IdentityServiceUrl { get; set; }
    }

    public class RedisSettings
    {
        public string HostName { get; set; }
        public string Port { get; set; }
        public string ConnectionString => $"redis://{HostName}:{Port}";
    }
}