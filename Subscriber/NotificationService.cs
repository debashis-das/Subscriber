using Amazon;
using Amazon.Runtime;
using JustSaying;
using JustSaying.AwsTools;
using Publisher;
using Topshelf;

namespace Subscriber
{
    class NotificationService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
			//Add keys here
            var tempCred = new BasicAWSCredentials("", "");
            CreateMeABus.DefaultClientFactory = () =>
                new DefaultAwsClientFactory(tempCred);
            var loggerFactory = new Log4NetProvider();

           /** var publisher = CreateMeABus.WithLogging(loggerFactory)
                .InRegion(RegionEndpoint.EUWest1.SystemName)
                .WithSnsMessagePublisher<BulkUpload>();**/

             CreateMeABus.WithLogging(loggerFactory)
                .InRegion(RegionEndpoint.EUWest1.SystemName)
                .WithSqsTopicSubscriber("BulkUpload")
                .IntoQueue("BulkUploadQueue")
                .WithMessageHandler<BulkUpload>(new BulkUploadNotifier())
                .StartListening();

           // publisher.Publish(new BulkUpload(123456));

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
