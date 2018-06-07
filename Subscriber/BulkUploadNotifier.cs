using System.Threading.Tasks;
using JustSaying.Messaging.MessageHandling;
using Publisher;

namespace Subscriber
{
    class BulkUploadNotifier:IHandlerAsync<BulkUpload>
    {
        public Task<bool> Handle(BulkUpload message)
        {
            
            return Task.FromResult(true);
        }
    }
}
