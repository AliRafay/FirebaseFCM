using FirebaseFCM.Standard;
using FirebaseFCM.Standard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Firebase.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirebaseController : ControllerBase
    {
        private readonly ILogger<FirebaseController> _logger;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        public FirebaseController(ILogger<FirebaseController> logger, 
            Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        [HttpPost(Name = "TriggerFcmNotification")]
        public async Task<bool> TriggerTestNotification([FromBody] FCMRequest request)
        {
            FirebaseFCMClient client = new FirebaseFCMClient.Builder().Build();
            var key = configuration.GetValue<string>("FirebaseServerKey");
            await client.MiscController.FCMMessagePOSTAsync($"Key={key}", new FCMMessagePOSTRequest
            {
                To = request.Token,
                Data = new Data
                {
                    Title = request.Title,
                    Body = request.Body
                }
            });
            return true;
        }
    }

    public class FCMRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Token { get; set; }

    }
}