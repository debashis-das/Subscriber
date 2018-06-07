using Topshelf;

namespace Subscriber
{
    class Program
    {

        static void Main(string[] args)
        {
            HostFactory.Run(
                c =>
                {
                    c.UseLog4Net("log4net.config");
                    c.Service(x => new NotificationService());
                    c.RunAsNetworkService();
                    c.SetDescription("Notification Service - Self-hosted Worker process.");
                });
        }
    }


}
